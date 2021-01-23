    [HttpPost]
    public ActionResult LogOn(UserModel user)
    {
       FormsAuthentication.SetAuthCookie(user.Username, false);
       return RedirectToActionPermanent("Index", "User");
    }
    
