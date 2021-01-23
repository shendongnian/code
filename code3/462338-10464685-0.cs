    private static List<string> GenerateTerms(string[] docs)
    {
    	var termsDictionary = new Dictionary<string, int>();
    
    	foreach (var doc in docs)
    	{
    		var terms = doc.Split(' ');
    		foreach (string term in terms)
    		{
    			if (termsDictionary.ContainsKey(term))
    				termsDictionary[term]++;
    			else
    				termsDictionary[term] = 1;
    		}
    	}
    
    	return (from entry in termsDictionary
    					orderby entry.Value descending
    					select entry.Key).Take(20000).ToList();
    }
