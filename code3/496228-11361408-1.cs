    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new MyVIewModel();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            return Content("Thanks for selecting role: " + model.SelectedRole);
        }
    }
