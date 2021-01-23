    public ActionResult LogoutProcess()
    {
        // TempData to transfer user name      
        TempData["previousLoggedIn"] = WebSecurity.CurrentUserName;
        WebSecurity.Logout();
        return RedirectToAction("Logout", "Home");
    }
    public ActionResult Logout(HomeModels.LogoutModel model)
    {
        // fill model from TempData
        model.PreviouslyLoggedInUsername = TempData["previousLoggedIn"];
        return View(model);
    }
