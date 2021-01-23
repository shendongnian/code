    var allDomains = Forest.GetCurrentForest().Domains.Cast<Domain>();
    
    var allSearcher = allDomains.Select(domain =>
    	{
    	  DirectorySearcher searcher = new DirectorySearcher(
            new DirectoryEntry("LDAP://" + domain.Name));
          searcher.Filter = String.Format(
            "(&(&(objectCategory=person)(objectClass=user)(userPrincipalName=*{0}*)))", 
            "Current User Login Name");
    
    	  return searcher;
    	}
    );
    
    var directoryEntriesFound = 
    allSearcher.SelectMany(searcher => 
                            searcher.FindAll()
                              .Cast<SearchResult>()
                              .Select(result => result.GetDirectoryEntry()));
    
    var memberOf = directoryEntriesFound.Select(entry =>
    	{
    	  using (entry)
    	  {
    		return new
    		{
    		  Name = entry.Name,
    		  GroupName = ((object[])entry.Properties["MemberOf"].Value)
                                .Select(obj => obj.ToString())
    		};
    	  }
    	}
    );
    
    foreach (var user in memberOf)
    {
    	foreach (var groupName in user.GroupName)
    	{
    	  if (groupName.Contains("Group to Find"))
    	  {
    		// Do something if the user is in that group
    	  }
    	}
    }
