    public static IEnumerable<string> GetTerms(Analyzer analyzer, string keywords)
    {
    	var tokenStream = analyzer.TokenStream("content", new StringReader(keywords));
    	var termAttribute = tokenStream.AddAttribute<ITermAttribute>();
    
    	var terms = new HashSet<string>();
    	
    	while (tokenStream.IncrementToken())
    	{
    		var term = termAttribute.Term;
    		if (!terms.Contains(term))
    		{
    			terms.Add(term);
    		}
    	}
    
    	return terms;
    }
