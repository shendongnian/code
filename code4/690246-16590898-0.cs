    public class HomeController : Controller
    {
        // The original page render will go here
        [HttpGet]
        public ActionResult Index()
        {
            return View(new MyModel());
        }
    
        // The form postback will go here
        [HttpPost]
        public String Index(MyModel model)
        {
            return "Something";
        }
    }
