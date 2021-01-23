    public ActionResult Index()
    {
         YourViewModel viewModel = new YourViewModel();
    
         return View(viewModel);
    }
    [HttpPost]
    public ActionResult Index(YourViewModel viewModel)
    {
         // Check viewModel for nulls
         // Whatever was typed in on the view you have here,
         // so now you can use it as you like
         string country = viewModel.CountryName;
         string id = viewModel.CountryId;
         // Do whatever else needs to be done
    }
