    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Modal()
        {
            return PartialView();
        }
    }
