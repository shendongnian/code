    public static string CreateUserAccount(string username, string password)
    {
        WebSecurity.CreateUserAndAccount(username, password);
        var roleProvider = (SimpleRoleProvider)Roles.Provider;
        roleProvider.AddUsersToRoles(new[] {username}, new[] {"MeterInfo", "SiteInfo", "AMRInfo", "InstallImages"});
        return username + " Account Created";
    }
