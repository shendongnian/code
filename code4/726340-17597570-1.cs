    public ActionResult LogOn(LogOnModel model)
    {
        if(String.IsNullOrWhitespace(model.UserName) && 
           String.IsNullOrWhitespace(model.Email)) 
        {
            ModelState.AddModelError("Username", "Either a username or email must be provided.");
        }
        if(ModelState.IsValid) {...}
        else {...}
    }
