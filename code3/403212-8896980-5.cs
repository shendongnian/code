    public class HomeController : AsyncController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LongPoll()
        {
            var service = new MyService();
            return new MyActionResult(service);
        }
    }
