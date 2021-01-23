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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Content("Thanks for selecting role: " + model.SelectedRole);
        }
    }
