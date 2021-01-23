    public ActionResult LogOn(LogOnModel model)
    {
        if(string.IsNullOrWhitespace(model.UserName) && 
           string.IsNullOrWhitespace(model.Email)) 
        {
            ModelState.AddError("Username", "Either a username or email must be provided.");
        }
        if(ModelState.IsValid) {...}
        else {...}
    }
