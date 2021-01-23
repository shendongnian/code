    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Image(string agha)
        {
            return new ImageResult(agha);
        }
    }
