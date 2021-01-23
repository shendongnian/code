    public class HomeController : Controller
    {
        [Authorize(Roles = "Reviewer, User")]
        public ActionResult Index()
        {
            if (Roles.IsUserInRole("Reviewer"))
            {
                ViewBag.Title = "Reviwer";
            }
            
            return View();
        }
    }
