    public ActionResult Login()
    {
        LoginViewModel model = new LoginViewModel();
        if ((HttpContext.User != null) &&
            (HttpContext.User.Identity.IsAuthenticated))
        {
            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }
    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        bool isAuthenticated = this.userService.IsPasswordValid(model.Email, model.Password);
        if (!isAuthenticated)
        {
            ModelState.AddModelError("AuthError", Resources.User.Login.AuthError);
            return View(model);
        }
        FormsAuthentication.SetAuthCookie(model.Email, model.RememberUser);
        return RedirectToAction("Index", "Home");
    }
