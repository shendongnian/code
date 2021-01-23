    [HttpPost]
    public ActionResult Index(HomeViewModel model)
    {
        /* Some logic here about model.Refresh */
        return View(model);
    }
