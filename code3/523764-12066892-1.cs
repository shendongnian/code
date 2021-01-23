    var userName = User.Identity.Name;
    var clientItems = db.MVCInternetApplicationPkg
        .Where(r => r.AgentsPkg.AgentLogin == userName).ToList();
    return View(clientItems);
     
