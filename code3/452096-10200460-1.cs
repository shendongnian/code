    using System.DirectoryServices.AccountManagement;
    public static string ChangePassword(string adminUser, string adminPassword,
        string domain, string container, string userName, string newPassword)
    {
        try
        {
            PrincipalContext principalContext = 
                new PrincipalContext(ContextType.Domain, domain, container, 
                    adminUser, adminPassword);
            UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, userName);
            if (user == null) return "User Not Found In This Domain";
            user.SetPassword(newPassword);
            return user.Name;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
