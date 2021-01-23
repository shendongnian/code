    private static List<string> GenerateTerms(string[] docs)
    {
    	var termsDictionary = new Dictionary<string, int>();
    
    	foreach (var doc in docs)
    	{
    		var terms = doc.Split(' ');
    		int uniqueTermsCount = 0;
    
    		foreach (string term in terms)
    		{
    			if (termsDictionary.ContainsKey(term))
    				termsDictionary[term]++;
    			else
    			{
    				uniqueTermsCount++;
    				termsDictionary[term] = 1;
    			}
    		}
    
    		if (uniqueTermsCount >= 20000)
    			break;
    	}
    
    	return (from entry in termsDictionary
    					orderby entry.Value descending
    					select entry.Key).ToList();
    }
