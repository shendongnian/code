    public ActionResult Index {
        var model = new MainViewModel();
        model.Partial1 = GetPartial1Data(); // this method would return Partial1ViewModel instance
        model.Partial2 = GetPartial2Data(); // same as above for Partial2ViewModel
        ...
        return View(model);
    }
