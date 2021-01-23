    public ActionResult Index()
    {
        var model = FooListViewModel();
        model.fooItems = ds.Foo.GetFilteredFoos(/* things */);
        return View(model);
    }
