    public class HomeController : Controller
     {
        public ActionResult Index()
        {
            ViewBag.Message = "This is from Index()";
            var model = DateTime.Now;
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult MyDateTime()
        {
            ViewBag.Message = "This is from MyDateTime()";
            var model = DateTime.Now;
            return PartialView(model);
        } 
    }
