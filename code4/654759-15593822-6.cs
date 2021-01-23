    [HttpPost]
    public ActionResult Login(LoginModel model, string returnUrl) 
    {
        if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie:     model.RememberMe))
        {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }
    // If we got this far, something failed, redisplay form
    ModelState.AddModelError("", "The user name or password provided is incorrect.");
    //recreate the compound viewmodel in the login controller
    Access viewModel = new Access();
    viewModel.LoginModel = model;
    viewModel.RegisterModel = new RegisterModel();
    return View("LoginOrRegister", viewModel);
}
