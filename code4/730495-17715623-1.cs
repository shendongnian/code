    var ldapConnectionString = "LDAP://servername/CN=Users,DC=domainname,DC=com";
    using (var de = new DirectoryEntry(ldapConnectionString, username, password, AuthenticationTypes.Secure))
    {
    	if(de.NativeObject != null)
    	{
    		// user is valid ...
    	}
    }
