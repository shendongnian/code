    public class HomeController : AsyncController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            var service = new MyService();
            return new MyActionResult(service);
        }
    }
