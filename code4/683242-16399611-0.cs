    IEnumerable<Tuple<String, IEnumerable<string>>> GuessGroups(IEnumerable<string> source, int minNameLength)
    {
    	// TODO: error checking
    	// assuming source is already in order
    	if(source.Any())
    	{
    		var b = GetBestGroup(source, minNameLength);
    		yield return Tuple.Create(b, source.TakeWhile(s => s.StartsWith(b)));
    		foreach (var element in GuessGroups(source.SkipWhile(s => s.StartsWith(b)), minNameLength))
    			yield return element;	
    	}
    }
    
    string GetBestGroup(IEnumerable<string> source, int minNameLength)
    {
    	var counter = new Dictionary<string, int>();
    	for(int j = source.Count(); j > 0; j--)
    	{
    		var g = GetCommonPrefix(source.Take(j));
    		if(!string.IsNullOrEmpty(g) && g.Length >= minNameLength)
    		{
    			if (counter.ContainsKey(g))
    				counter[g]++;
    			else
    				counter[g] = 1;
    		}
    	}
    	return counter.OrderBy(c => c.Value).Last().Key;
    }
    
    string GetCommonPrefix(IEnumerable<string> coll)
    {
     	return (from len in Enumerable.Range(0, coll.Min(s => s.Length)).Reverse()
                let possibleMatch = coll.First().Substring(0, len)
                where coll.All(f => f.StartsWith(possibleMatch))
                select possibleMatch).FirstOrDefault();
    }
