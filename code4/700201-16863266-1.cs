    public class UserController : Controller 
    {
            public ActionResult Index()
            {
                var allUsers = UserBusLayer.User.GetAll();
                return View(allUsers);
            }
    }
