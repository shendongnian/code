    if (some condition)
    {
        var Info = db.tblGames.Include(x => x.tblConsole).Where(UserInfo => UserInfo.UserName.Equals(User.Identity.Name)).ToList();
        return View(Info);
    }
