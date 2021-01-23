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
        FormsAuthenticationTicket ticket =
            new FormsAuthenticationTicket(
                1,
                model.Email,
                DateTime.Now,
                DateTime.Now.AddDays(1),
                true,
                string.Empty);
        string hashedTicket = FormsAuthentication.Encrypt(ticket);
        HttpCookie cookie =
            new HttpCookie(
                FormsAuthentication.FormsCookieName,
                hashedTicket);
        HttpContext.Response.Cookies.Add(cookie);
        return RedirectToAction("Index", "Home");
    }
