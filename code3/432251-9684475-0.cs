    static void Main(string[] args) {
        string userDomain = "somedomain";
        string userName = "username";
        string password = "apassword";
        if (IsDomainAdmin(userDomain, userName)) {
            string fullUserName = userDomain + @"\" + userName;
            PrincipalContext context = new PrincipalContext(
                ContextType.Domain, userDomain);
            if (context.ValidateCredentials(fullUserName, password)) {
                Console.WriteLine("Success!");
            }
        }
    }
    public static bool IsDomainAdmin(string domain, string userName) {
        string adminDn = GetAdminDn(domain);
        SearchResult result = (new DirectorySearcher(
            new DirectoryEntry("LDAP://" + domain),
            "(&(objectCategory=user)(samAccountName=" + userName + "))",
            new[] { "memberOf" })).FindOne();
        return result.Properties["memberOf"].Contains(adminDn);
    }
    public static string GetAdminDn(string domain) {
        return (string)(new DirectorySearcher(
            new DirectoryEntry("LDAP://" + domain),
            "(&(objectCategory=group)(cn=Domain Admins))")
            .FindOne().Properties["distinguishedname"][0]);
    }
