     public ActionResult Logout()
     {
        Upload.Models.CompteModels.Connected = false;
        Session.Remove("LoggedIn");
        return RedirectToAction("Login", "Account");
     }
     public ActionResult Login()
     {
        // check for session var, redirect to landing page maybe?
        if(Session["LoggedIn"] == null) 
        {
           RedirectToAction("Home", "Index");
        }
        else
        {
           Session.Add("LoggedIn", true);
        }
        return RedirectToAction("TargetPage", "TargetAction");
     }
