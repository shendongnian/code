    public class UsersController: Controller
    {
        public ActionResult Index()
        {
            var users = new UserViewModel[]
            {
                // TODO: obviously those could come from a database or something
                new UserViewModel { UserId = 1, Name = "user 1" },
                new UserViewModel { UserId = 2, Name = "user 2" },
                new UserViewModel { UserId = 3, Name = "user 3" },
            };
            return View(users);
        }
    
        public ActionResult Index(UserViewModel[] users)
        {
            ... you could inspect the IsSelected property of each user here        
        }
    }
