    var userName = User.Identity.Name;
    var clientItems = db.MVCInternetApplicationPkg
        .Where(r => r.ClientAgent.AgentLogin == userName ).ToList();
    return View(clientItems);
     
