    using (SvnClient client = new SvnClient())
    
    {
    
    	//delete all Svn Authentication credential stored in the computer    
    	foreach (var svnAuthenticationCacheItem in client.Authentication.GetCachedItems(SvnAuthenticationCacheType.UserNamePassword))    
    	{   
    		svnAuthenticationCacheItem.Delete();    
    	}
    
    }  
