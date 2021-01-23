    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    
    // find user by name
    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "Kernal  Sanders");
    
    // if we found user - inspect its details
    if(user != null)
    {
        string firstName = user.GivenName;
        string lastName = user.Surname;
        string email = user.EmailAddress;
        string phone = user.VoiceTelephoneNumber;
    }
    etc....
    The new S.DS.AM makes it really easy to play around with users and groups in AD:
