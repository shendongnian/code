    // Define other methods and classes here
    static IEnumerable<IEnumerable<T>> CustomSplit<T>(this IEnumerable<T> source, int max)
    {
    	var results = new List<List<T>>();
    	for (int i = 0; i < max; i++)
    	{
    		results.Add(new List<T>());
    	}
    	
    	int index = 0;
    	using (var enumerator = source.GetEnumerator())
    	{
    		while (enumerator.MoveNext())
    		{
    			int circularIndex = index % max;
    			results[circularIndex].Add(enumerator.Current);
    			index++;
    		}
    	}
    	
    	return results;
    }
