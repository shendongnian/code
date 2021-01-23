    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(Database.Users.OrderBy(p => p.Name).ToList());
        }
    }
