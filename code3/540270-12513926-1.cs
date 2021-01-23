    public ActionResult Index()
    {
        var model = new MyModel();
        model.UnactivatedHeaders.Add("GT5C");
        // and so on...
        return View(model);
    }
