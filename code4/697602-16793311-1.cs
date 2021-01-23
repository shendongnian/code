    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel();
            return View(model);
        }
    
        public ActionResult Index(MyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // there was a validation error => redisplay the view
                return View(model);
            }
    
            // success
            return Content("Thanks for submitting the form");
        }
    }
