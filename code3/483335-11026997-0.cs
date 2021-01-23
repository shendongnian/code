    // set up machine-level context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Machine))
    {
        // create new user
        UserPrincipal newUser = new UserPrincipal(ctx);
        
        // set some properties
        newUser.SamAccountName = "Sam";
        newUser.DisplayName = "Sam Doe";
        // define new user to be enabled and password never expires
        newUser.Enabled = true;
        newUser.PasswordNeverExpires = true;
        // save new user
        newUser.Save();
    }
