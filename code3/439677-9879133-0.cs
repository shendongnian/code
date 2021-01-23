    string searchString = "Jones";
    string lowerSS = searchString.ToLower();
    
    List<NameClass> nameClasses; 
    
    var results = nameClasses.Where(nc => nc.Name.ToLower().StartsWith(lowerSS));
    
    if(results != null && results.Count() >= 3)
    {
    	return results;
    }
    else
    {
        return null;
    }
