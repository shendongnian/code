    // this is your DAL class
    public class User
    {
    }
    // a view model to wrap the DAL class    
    public class UserViewModel
    {
        // a special instance of the view model to represent all users
        public static readonly UserViewModel AllUsers = new UserViewModel(null);
        private readonly User user;
    
        public UserViewModel(User user)
        {
            ...
        }
        // view binds to this to display user
        public string Name
        {
            get { return this.user == null ? "<<All>>" : this.user.Name; }
        }
    }
    
    public class MainViewModel()
    {
        private readonly ICollection<UserViewModel> users;
    
        public MainViewModel()
        {
            this.users = ...;
            this.users.Add(UserViewModel.AllUsers);
        }
    
        public ICollection<UserViewModel> Users
        {
            ...
        }
    }
