    using (var de = new DirectoryEntry(ldapConnectionString, username, password, AuthenticationTypes.Secure))
    {
    	if(de.NativeObject != null)
    	{
    		// user is valid ...
    	}
    }
