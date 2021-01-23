    public static IEnumerable<T> Interleave<T>(IEnumerable<IEnumerable<T>> sequences)
    {
    	var enumerators = new List<IEnumerator<T>>();
    	try
    	{
    		// using foreach here ensures that `enumerators` contains all already obtained enumerators, in case of an expection is thrown here.
    		// this ensures proper disposing in the end
    		foreach(var enumerable in sequences)
    		{
    			enumerators.Add(enumerable.GetEnumerator());
    		}
    	
    		var queue = new Queue<IEnumerator<T>>(enumerators);	
    		while (queue.Any())
    		{
    			var enumerator = queue.Dequeue();
    			if (enumerator.MoveNext())
    			{
    				queue.Enqueue(enumerator);
    				yield return enumerator.Current;
    			}
    		}
    	}
    	finally
    	{
    		foreach(var enumerator in enumerators)
    		{
    			enumerator.Dispose();
    		}
    	}
    }
