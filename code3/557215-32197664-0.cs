    public ActionResult Login(string returnUrl) 
    {
        if (WebSecurity.IsAuthenticated)
            return RedirectToAction("LogOff");
        ...
    }
