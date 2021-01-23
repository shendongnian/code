    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
       // validate given user credentials
       bool isValid = ctx.ValidateCredentials(user, password);
       // find a user
       UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
    
       if(user != null)
       {
          string surname = user.Surname;
          string givenName = user.GivenName;
       }
    }    
