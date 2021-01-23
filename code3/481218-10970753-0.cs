    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home",
                new { area = "Administrator" });
        }
    }
