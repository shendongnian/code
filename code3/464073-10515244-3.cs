    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // mock data
            var model = new MyViewModel
                                {BookVars = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}}};
    
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // the binded model is avaliable
            return View(model);
        }
    }
