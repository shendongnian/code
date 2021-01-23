    [Anonymous]
    public ActionResult Login(LoginModel model)
    {
        // TODO: check credentials, ...
        FormsAuthentication.SetAuthCookie(model.Username, false);
        //something else
        // finally redirect and inside the target controller action
        // you will be able to retrieve the authenticated user
        return RedirectToAction("SomeProtectedAction");
    } 
