    public ActionResult DetailForm()
    {
        var ceremonies = _ceremonyService.GetAllCeremonyByDate(DateTime.Now);
        if (ceremonies.Count == 0)
        {
            return Content("No ceremony can be loaded");
        }
        else
        {
            return View(ceremonies.First());
        }
    }
