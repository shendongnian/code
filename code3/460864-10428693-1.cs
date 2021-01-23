    private string GetUserName(string identity)
    {
    	if (identity.Contains("\\"))
    	{
    		string[] identityList = identity.Split('\\');
    		return identityList[1];
    	}
    	else
    	{
    		return identity;
    	}
    }
    
    public string GetUserDn(string identity)
    {            
    	var userName = GetUserName(identity);	
    	using (var rootEntry = new DirectoryEntry("LDAP://" + adConfiguration.ServerAddress, null, null, AuthenticationTypes.Secure))
    	{		
    		using (var directorySearcher = new DirectorySearcher(rootEntry, String.Format("(sAMAccountName={0})", userName)))
    		{
    			var searchResult = directorySearcher.FindOne();                    
    			if (searchResult != null)
    			{
    				using (var userEntry = searchResult.GetDirectoryEntry())
    				{
    					return (string)userEntry.Properties["distinguishedName"].Value;					
    				}
    			}
    		}                
    	}	
    	return null;
    }        
