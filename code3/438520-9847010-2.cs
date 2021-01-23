    using System.DirectoryServices.AccountManagement;
    private string GetUserIdFromDisplayName(string displayName)
    {
        // set up domain context
        using(PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
            // find user by display name
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, displayName);
 
            // 
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
