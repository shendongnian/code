    public ActionResult Index()
    {
        var model = new MyViewModel();
    
        // the list of available values
        model.Values = new[]
        {
            new SelectListItem { Value = "2", Text = "2", Selected = true },
            new SelectListItem { Value = "3", Text = "3", Selected = true },
            new SelectListItem { Value = "6", Text = "6", Selected = true }
        };
    
        return View(model);
    }
