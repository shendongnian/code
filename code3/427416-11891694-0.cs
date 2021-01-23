    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Code...
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //Code...
            return View();
        }
    }
