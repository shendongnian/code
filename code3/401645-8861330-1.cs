    public class HeadlinesController: Controller
    {
        public ActionResult Index()
        {
            var model = new NewsViewModel();
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(NewsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // there were validation errors. For example the user
                // left the headline field blank => redisplay the view
                return View(model);
            }
    
            // at this stage we know that validation passed => we can 
            // process our domain model.
            var news = new News();
            news.posted = model.Posted;
            news.headline = model.Headline;
    
            return RedirectToAction("success");
        }
    }
