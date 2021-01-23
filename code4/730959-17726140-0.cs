    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return MoreIndex();
        }
        public ActionResult MoreIndex()
        {
            return View();
        }
    }
