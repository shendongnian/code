    private static string GetDNOfUser(string user)
    {
    	var ctx = new PrincipalContext(ContextType.Domain, Environmentals.Domain, Environmentals.OUPath);
    
    	//Creating object for search filter
    	UserPrincipal userPrin = new UserPrincipal(ctx)
    	{
    		//Only getting users with the same name as the input
    		Name = user
    	};
    
    	var searcher = new PrincipalSearcher
    	{
    		//Applying filter to query
    		QueryFilter = userPrin
    	};
    
    	//Finding the user
    	var results = searcher.FindOne();
    	searcher.Dispose();
    
    	//Return the distinguishedname
    	return results.DistinguishedName;
    }
