    using System.DirectoryServices.AccountManagement;
    private string GetUserIdFromDisplayName(string displayName)
    {
        // set up domain context
        using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
            // define a "query-by-example" principal - here, we search for a UserPrincipal 
            // and with the display name passed in
            UserPrincipal qbeUser = new UserPrincipal(ctx);
            qbeUser.DisplayName = displayName;
            // create your principal searcher passing in the QBE principal    
            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
            // find match - if exists
            UserPrincipal user = srch.FindOne() as UserPrincipal;
        
            if (user != null)
            {
                 return user.SamAccountName;
                 // or maybe you need user.UserPrincipalName;
            }
            else
            {
                 return string.Empty;
            }
        }
    }
