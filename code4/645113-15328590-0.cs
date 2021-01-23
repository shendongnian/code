    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
    
        if (User.Identity.IsAuthenticated && Roles.IsUserInRole("Registered User"))
            return RedirectToAction("LandingPage");
    
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }
