    public class HomeController : Controller
    {
        [Authorize(Roles = "Reviewer", "User")]
        public ActionResult Index()
        {
            if (User.IsInRole("Reviewer"))
            {
                return View("Reviewer");
            }
            else
            {
                return View("User");
            }
        }
    }
