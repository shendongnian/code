    public class CarsController: Controller
    {
        public ActionResult Add()
        {
            var model = new CarViewModel
            {
                // don't ask me, those are the values you hardcoded in your view
                ID = 1,
                UserID = 44,
            };
            return View(model);
        }   
    
        [HttpPost]
        public PartialViewResult Add(CarViewModel model)
        {
            ...
        }
    }
