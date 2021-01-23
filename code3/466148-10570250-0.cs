    [HttpPost]
    public ActionResult Process(OnePersonAllInfoViewModel model)
    {
        ViewBag.PrefContactTypes = ...
        return View(model);
    }
