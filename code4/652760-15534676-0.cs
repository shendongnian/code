    public class HomeController : Controller
    {
        [Authorize(Roles = "Reviewer,User")]
        public ActionResult Index()
        {
        if (User.IsInRole("Reviewer")){
    
                ViewBag.Title = "Reviwer";
                return View("IndexReviwer");
         }
        return View();
        }
    }
