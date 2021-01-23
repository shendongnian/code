    public ActionResult Index()
    {
        var model = new MyViewModel
        {
            Search = new SearchViewModel
            {
                Keywords = "some initial value"
            }
        };
        return View(model);
    }
