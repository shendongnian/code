    if (ModelState.IsValid && IsValidUser(model.UserName, model.Password))
    {
        FormsAuthentication.SetAuthCookie("FooBar", false);
        return RedirectToAction("Index", "Home");
    }
