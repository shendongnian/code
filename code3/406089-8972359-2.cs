    public class CurrentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitMe(SomeModel someModel)
        {
            // do what you have to do here
            return RedirectToAction("Home", "Home");
        }
    }
