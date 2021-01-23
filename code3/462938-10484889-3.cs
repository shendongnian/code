    public ActionResult Index()
    {
        var model = new MyViewModel();
        model.Values = new[]
        {
            new SelectListItem { Value = "1", Text = "item 1" },
            new SelectListItem { Value = "2", Text = "item 2" },
            new SelectListItem { Value = "3", Text = "item 3" },
        };
        return View(model);
    }
