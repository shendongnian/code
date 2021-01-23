    public class MyController : Controller
    {
        //
        // GET: //
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MyModel model)
        {
            string x = "Hello "+ model.name;
            return View();
        }
    }
