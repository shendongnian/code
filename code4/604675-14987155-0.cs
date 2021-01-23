    //Domain related info
    string _DCToUse = "myserver.domain.local";
    string _ADConDomain = "DC=domain,DC=local";
    string _AdDomain = "domain";
    string _ADAdminUser = "administrator";
    string _ADAdminPass = "password";
    
    //User specific
    string _UserName = "jsmith";
    string _CurrentPass = "oldPass";
    string _NewPass = "newPass";
    
        PrincipalContext principalContext =
          new PrincipalContext(ContextType.Domain, _DCToUse,
          _ADConDomain, _ADDomain+@"\"+_ADAdminUser, _ADAdminPass);
        UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, _UserName);
    
            if (user == null)
            {
                 string ADErrorMsg = "Couldn't find user, check your spelling.";
                 return Changed;
            }
    
            user.ChangePassword(oldPass, newPass);
            user.Save();
