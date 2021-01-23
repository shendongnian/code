    using(DirectoryEntry de = new DirectoryEntry("LDAP://domain.local/dc=domain,dc=local", "user", "password"))
    using(DirectorySearcher ds = new DirectorySearcher(de))
    {
    	ds.Filter="(&(objectCategory=user)(objectClass=user))";
    	ds.PageSize= 1000;
    	ds.PropertiesToLoad.Clear();
    	ds.PropertiesToLoad.Add("objectGuid");
    
    	var results = ds.FindAll();
    	var searchResults = results.Cast<System.DirectoryServices.SearchResult>().ToArray();
    	int myDesiredPageSize = 2000;
    	
    	var upns = new StringCollection();
    	
    	for(var step=0; step < Math.Ceiling((double)results.Count / myDesiredPageSize); step++)
    	{
    		Parallel.ForEach(searchResults.Skip(step*myDesiredPageSize).Take(myDesiredPageSize), result => {
    		using(var entry = result.GetDirectoryEntry())
    		{
    			entry.RefreshCache(new[]{ "userPrincipalName" });
    			
    			if(entry.Properties.Contains("userPrincipalName"))
    				upns.Add(entry.Properties["userPrincipalName"][0] as string);
    		}
    		});
    	}
    	
    	upns.Count.Dump();
    }
