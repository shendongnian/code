    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyViewModel
            {
                IntegerParameter = 1111,
                StringParameter = "AA'AA\"AA"
            });
        }
        [HttpPost]
        public ActionResult MyAction()
        {
            return Json(new { foo = "bar" });
        }
    }
