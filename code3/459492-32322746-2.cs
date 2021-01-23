    public class MyFinalViewController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.PropertyName = "My ViewBag value!";
            return View();
        }
    }
