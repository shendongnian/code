    public class HomeController : Controller
    {
        public ActionResult Application()
        {
            var model = new Application();
            model.ShowSideBars = true;
            return View(model);
        }
        [HttpPost]
        public ActionResult Application(Application application)
        {
            return Content(application.ShowSideBars.ToString());
        }
    }
