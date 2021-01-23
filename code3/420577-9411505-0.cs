    private string GetLDAPConnection(string a_Domain, string a_Username, string a_Password)
    {
        // Get the domain controller server for the specified domain
        NameValueCollection domains = (NameValueCollection)ConfigurationManager.GetSection("domains");
        string domainController = domains[a_Domain.ToLower()];
    
        string ldapConn = string.Format("LDAP://{0}/rootDSE", domainController);
    
        DirectoryEntry root = new DirectoryEntry(ldapConn, a_Username, a_Password);
        string serverName = root.Properties["defaultNamingContext"].Value.ToString();
        return string.Format("LDAP://{0}/{1}", domainController, serverName);
    }
