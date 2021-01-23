    public ActionResult Details(int id = 0)
    {
        Teams teams = db.Teams.Find(id);
        if (teams == null)
        {
            return HttpNotFound();
        }
        // get the list of players into a List<Players>
        var players ...
        var model = new Tuple<Teams, List<Players>>(teams, players);
        return View(model);
    }
