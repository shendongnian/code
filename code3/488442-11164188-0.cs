    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateForm()
        {
            return Content(DateTime.Now.ToLongTimeString());
        }
    }
