    public class UserInfoController: Controller
    {
        [ChildActionOnly]
        public ActionResult Index()
        {
            var model = new UserDetailsViewModel();
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                // fetch the user info from the database and populate your view model
                // consider caching this information to avoid multiple round-trips 
                // to the database
            }
    
            return PartialView(model);
        }
    }
