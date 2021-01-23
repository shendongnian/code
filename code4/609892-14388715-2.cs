    public class ProfileController: Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var user = DataAccess.DAL.GetUser(User.Identity.Name);
            return View(user);
        }
    }
