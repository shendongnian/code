    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                StartDate = DateTime.Now.AddDays(2),
                DateToCompareAgainst = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            return View(model);
        }
    }
