    [HttpPost]
    public ActionResult LogOn(string username, string password)
    {
        // TODO: up to you to implement the VerifyCredentials method
        if (!VerifyCredentials(username, password))
        {
            // wring username or password:
            ModelState.AddModelError("", "wrong username or password");
            return View();
        }
    
        // username and password match => emit an authentication cookie:
        FormsAuthentication.SetAuthCookie(username, false);
        return RedirectToAction("SomeProtectedAction", "SomeController");
    }
