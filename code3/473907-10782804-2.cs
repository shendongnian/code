    public ActionResult Index()
    {
        var model = new HomeViewModel(); //class with the bits needed for you view
        model.Articles = _dataservice.GetArticles(); //irrelevant how _dataService was intialised
        return View(model);
    }
