    public static bool LogonValid(string ldapDomain, string userName, string password) {
        DirectoryEntry de = new DirectoryEntry(@"LDAP://" + ldapDomain, userName, password);
    
      try {
    	object o = de.NativeObject;
    	return true;
      }
        catch (Exception ex) {
    	logger.Error(ex.ToString());
    	return false;
      }
    }
