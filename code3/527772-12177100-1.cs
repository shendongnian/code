    public ActionResult Index()
    {
        var model = new MyViewModel();
        // preselect items with values 2 and 4
        model.SelectedValues = new[] { 2, 4 };
        
        // the list of available values
        model.Values = new[]
        {
            new SelectListItem { Value = "1", Text = "item 1" },
            new SelectListItem { Value = "2", Text = "item 2" },
            new SelectListItem { Value = "3", Text = "item 3" },
            new SelectListItem { Value = "4", Text = "item 4" },
        };
    
        return View(model);
    }
