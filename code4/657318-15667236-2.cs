    public ActionResult View(int id) 
    { 
        // get the menu from the cache, by Id 
        ViewBag.SideBarMenu = SideMenuManager.GetRootMenu(id); 
        return View(); 
    } 
    
    public ActionResult RoleUser(RoleView rvw) 
    { 
        var rosterUser = new RosterService().GetUsers(); 
        ViewBag.RosterUsers = rosterUser; 
        return View(); 
    }
