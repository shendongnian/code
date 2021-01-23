    public ActionResult DetailForm()
    {
        var model = _ceremonyService.GetAllCeremonyByDate(DateTime.Now);
        if (model.Count == 0)
        {
            return Content("No ceremony can be loaded");
        }
        else
        {
            return View(model);
        }
    }
