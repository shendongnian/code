    [Authorize]
    public ActionResult LogOff() {
        //Get from session the name of the original user that was logged in and started impersonating the current user.
        var originalLoggedInUser = UserService.GetImpersonateCache(WebsiteUser.Email);
        if (string.IsNullOrEmpty(originalLoggedInUser)) {
            FormsAuthentication.SignOut();
        } else {
            FormsAuthentication.SetAuthCookie(originalLoggedInUser, false);
        }
        return RedirectToAction("Index", "Home");
    }
