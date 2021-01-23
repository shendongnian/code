    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                BookVars = Enumerable.Range(1, 5).ToDictionary(x => "key" + x, x => "value" + x)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // the model.BookVars property will be properly bound here
            return View(model);
        }
    }
