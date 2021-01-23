    public class BaseController : Controller
    {
        public BaseController()
        {
            //You can load the CurrentUser and Settings here
            CurrentUser = new User
            {
                Id = 1
            };
            PersonalSettings = new UserSettings
            {
                Id = 1
            };
        }
        public User CurrentUser { get; set; }
        public UserSettings PersonalSettings { get; set; }
    }
