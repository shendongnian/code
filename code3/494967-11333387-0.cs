    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //do your text magix
            return View("Index", model: "your text here");
        }
    }
