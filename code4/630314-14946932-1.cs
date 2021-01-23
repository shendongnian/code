    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel();
            model.AllHumans = returnAllHuman(); // List<SelectListItem>
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // there was a validation error => for example the user didn't make
                // any selection => rebind the AllHumans property and redisplay the view
                model.AllHumans = returnAllHuman();
                return View(model);
            }
    
            // at this stage we know that the model is valid and model.SelectedHuman
            // will contain the selected value
            // => we could do some processing here with it
            return Content(string.Format("Thanks for selecting: {0}", model.SelectedHuman));
        }
    }
