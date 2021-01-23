    public class HomeController : Controller
    {
        [MyActionFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
