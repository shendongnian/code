    [Authorize] //I use a custom authorize attribute; just make sure this is secured to only certain users.
    public ActionResult Impersonate(string email) {
        var user = YourMembershipProvider.GetUser(email);
        if (user != null) {
            //Store the currently logged in username in session so they can be logged back in if they log out from impersonating the user.
            UserService.SetImpersonateCache(WebsiteUser.Email, user.Email);
            FormsAuthentication.SetAuthCookie(user.Email, false);
        }
        return new RedirectResult("~/");
    }
