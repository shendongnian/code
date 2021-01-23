    public partial class MainWindow : UserControl
    {
        private readonly IUserService _userService;
        public MainWindow(IUserService userService)
        {
            _userService = userService;
        }
        // Example method consuming the service
        public IEnumerable<User> GetUsers()
        {
            return _userService.Users();
        }
    }
