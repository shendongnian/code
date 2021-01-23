    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // ... model.SelectedMaritalStatus will contain the selected value (0 or 1)
        }
    }
