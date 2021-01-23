    public ActionResult Index()
    {
         var products = SomeDataAccessClass.GetProducts();
         return View(products);
    }
