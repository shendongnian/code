    public class MyAwesomeController : Controller
    {
        private MyProjectContext db = new MyProjectContext();
        public ActionResult Index()
        {
            var someModels = db.SomeModels;
            return View(someModels);
        }
        public ActionResult GetSomeModel(int id)
        {
            var someModel = db.SomeModels.Find(id);
            return View(someModel);
        }
        # other actions
    }
