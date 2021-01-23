    public ActionResult Index()
    {
        var model = new OnePersonAllInfoViewModel();
        model.PrefContactTypes = dbEntities
            .PreferredContactTypes
            .OrderBy(pct => pct.PreferredContactTypeID)
            .ToList();
        return View(model);
    }
