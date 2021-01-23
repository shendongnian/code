    public ActionResult Add()
    {
        var viewModel = new ListViewModel { MyList = db.lat.ToList() };
        return View(viewModel);
    }
