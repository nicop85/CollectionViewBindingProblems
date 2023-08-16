using System.Collections.ObjectModel;

namespace CollectionViewBindingProblems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<UserDTO> Users { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Users = new();

            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var list = await GetUsersList();

            Users.Clear();

            foreach (var user in list)
            {
                Users.Add(user);
            }
        }

        private async Task<List<UserDTO>> GetUsersList()
        {
            // Wait for a couple of seconds to emulate we are looking for the data in an external API
            await Task.Delay(2000);

            return new List<UserDTO>()
            {
                new()
                {
                    FullName = "User 1"
                },
                new()
                {
                    FullName = "User 2"
                },
                new()
                {
                    FullName = "User 3"
                },
                new()
                {
                    FullName = "User 4"
                },
                new()
                {
                    FullName = "User 5"
                },
                new()
                {
                    FullName = "User 6"
                },
                new()
                {
                    FullName = "User 7"
                }
            };
        }
    }

    public class UserDTO
    {
        public string FullName { get; set; }
    }
}