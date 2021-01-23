    [HttpPost]
    public ActionResult ChangePassword(LoginModel model)
    {
        if (ModelState.IsValid && _userService.ChangePassword(model.Password, model.NewPassword))
            ViewBag.SuccessMessage = UI.PasswordChanged;
        else
            ModelState.AddModelError("Password", ErrorMessages.InvalidPassword);
        return View(model);
    }
