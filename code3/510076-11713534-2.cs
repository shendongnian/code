    public class FooController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.SelectedTab = "Bar";
            return View();
        }
        public ActionResult Bar()
        {
            if(Request.Headers["X-PJAX"] != null)
                return PartialView();
            ViewBag.SelectedTab = "Bar";
            return View("Index");
        }
        public ActionResult Baz()
        {
            if (Request.Headers["X-PJAX"] != null)
                return PartialView();
            ViewBag.SelectedTab = "Baz";
            return View("Index");
        }
    }
