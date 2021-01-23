    public ActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
        {
            if (Roles.IsUserInRole("Tenant"))
            {
                return RedirectToAction("MyProfile", "Tenants");
            }
        }
    
        // If we got this far, something failed, redisplay form
        ModelState.AddModelError("", "The user name or password provided is incorrect.");
        return Content("Hello User");
    }
