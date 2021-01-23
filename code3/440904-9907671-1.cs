    [Authorize]
    public ActionResult SomeProtectedAction()
    {
        string username = User.Identity.Name;
    
        // TODO: here you could query your database to find out more about 
        // the user given his username which must be unique
        ...
    }
