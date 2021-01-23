    [HttpPost, ActionName("Submit")]
    public ActionResult Login(LoginCredential credentials)
    {    
        String Username = credentials.UserName ;
        String Password = credentials.Password ;
        Int OrganizationId = credentials.OrganizationId;
        ///  Rest of your code goes here
    }
