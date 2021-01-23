    public ActionResult ChangePassword()
    {
        if (!User.Identity.IsAuthenticated)
            return RedirectToAction("LogOn", "Account");
     
        ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
        return View();
    }
