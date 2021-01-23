    public ActionResult Details(int id = 0)
    {
        Teams teams = db.Teams.Find(id);
        if (teams == null)
        {
            return HttpNotFound();
        }
        return View(teams);
    }
