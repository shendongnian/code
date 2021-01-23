    protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
    {
        //Obtain username and roles from application datastore and use them in the next line
        Thread.CurrentPrincipal = new GenericPrincipal(
            new GenericIdentity("userNameHere"),
            new string[] { "Admin", "CanDeleteStuff", "CanEditStuff", "OtherRole" }
        );
    }
