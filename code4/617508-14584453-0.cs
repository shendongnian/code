    [HttpPost]
    public ActionResult Login(LoginViewModel model, String returnUrl)
    {
        if (ModelState.IsValid)
        {
            // perform login
            if (YourFormsAuthentication.YourLoginMethod(mode.username, model.password))
            {
                //
                // Set auth cookie, log user in, etc.
                //
                // Now check for returnUrl and make sure it's present and
                // valid (not redirecting off-site)
                if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                // no returnUrl provided, direct them to default landing page
                return RedirectToRoute("Home");
            }
            else
            {
                ModelState.AddError("", "Username or password are incorrect.");
            }
        }
        return View(model);
    }
