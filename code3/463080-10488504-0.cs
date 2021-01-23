    public ActionResult Overview(int id)
    {
        TempData["YourId"] = id;
        return View(new OverviewModel() { Project = db.People.Find(id) });
    }
    public ActionResult About(int? id)
    {
        id = id ?? int.Parse(TempData["YourId"].ToString());
        return View(new AboutModel() { Project = db.People.Find(id) });
    }
