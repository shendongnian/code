    public ViewResult Index()
    {
        var pageSize = 3;
        var pageNumber = (CounterForPage ?? 1);
        var Info = db.tblGames
            .Include(x => x.tblConsole)
            .Where(UserInfo => UserInfo.UserName.Equals(User.Identity.Name))
            .Skip(pageSize * (CounterForPage - 1)) // skip first 0, 3, 6, 9, 12, etc, rows
            .Take(pageSize) // give me only this many rows from the db
            .ToList();
        return View(Info);
    }
