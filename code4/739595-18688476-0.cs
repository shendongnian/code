    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            if (Membership.ValidateUser(model.UserName, model.Password))
            {
                var profile = MvcTFAProfile.GetProfile(model.UserName);
                if (profile.UsesTwoFactorAuthentication)
                {
                    TempData[CurrentUserTempDataKey] = profile;
                    TempData[RememberMeTempDataKey] = model.RememberMe;
                    return RedirectToAction("SecondFactor", new {returnUrl = returnUrl});
                }
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
        }
        // If we got this far, something failed, redisplay form
        ModelState.AddModelError("", "The user name or password provided is incorrect.");
        return View(model);
    }
