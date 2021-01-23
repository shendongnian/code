    public ActionResult Index()
    {
        return View(new ExampleModel());
    }
    [HttpPost]
    public ActionResult Index(ExampleModel model)
    {
        if (model.AutoId == 0 && String.IsNullOrEmpty(model.VIN))
            ModelState.AddModelError("OneOfTwoFieldsShouldBeFilled", "One of two fields should be filled");
        if (model.AutoId != 0 && !String.IsNullOrEmpty(model.VIN))
            ModelState.AddModelError("OneOfTwoFieldsShouldBeFilled", "One of two fields should be filled");
        if (ModelState.IsValid)
        {
            return null;
        }
        return View();
    }
