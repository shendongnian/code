    public ActionResult Index()
        {
           
            //you don't need to include the category bc it does it by itself
            //var model = db.Product.Include(c => c.Category).ToList()
 
            ViewBag.Categories = db.Category.OrderBy(c => c.Name).ToList();
            var model = db.Product.ToList()
            return View(model);
        }
