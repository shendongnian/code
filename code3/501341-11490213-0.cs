    public ActionResult LogOn(LogOnModel Model)
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction(...);
        }
        .. login logic
    
        return View(Model);
    }
