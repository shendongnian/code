    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Some Code--Some Code---Some Code
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(formViewModel model)
        {
            do work on model --
            return View();
        }
    
    }
