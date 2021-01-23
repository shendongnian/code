    [HttpPost]
    public ActionResult LogOn(string username, string password)
    {
        // TODO: up to you to implement the VerifyCredentials method
        if (!VerifyCredentials(username, password))
        {
            // wrong username or password:
            ModelState.AddModelError("", "wrong username or password");
            return View();
        }
    
        // username and password match => emit an authentication cookie:
        FormsAuthentication.SetAuthCookie(username, false);
 
        // and redirect to some controller action which is protected by the
        // [Authorize] attribute and which should be accessible only to 
        // authenticated users
        return RedirectToAction("SomeProtectedAction", "SomeController");
    }
