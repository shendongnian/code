    public class HomeController : Controller
    {
        [Authorize(Roles = "Reviewer")]
        public ActionResult Reviewer()
        {
            ViewBag.Title = "Reviewer";
            return View();
        }
        [Authorize(Roles="User")]
        public ActionResult User()
        {
            return View();
        }
    }
