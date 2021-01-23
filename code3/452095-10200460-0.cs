    using System.DirectoryServices.AccountManagement;
    public static string ChangePassword(string identity, 
        string oldPassword, string newPassword)
    {
        try
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, identity);
            if (user == null) return "User Not Found In This Domain";
            user.ChangePassword(oldPassword, newPassword);
            return user.Name;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
