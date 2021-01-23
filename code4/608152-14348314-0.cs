    public static List<List<T>> PartitionBy<T>(this IEnumerable<T> seq, Func<T, bool> predicate)
    {
    	bool lastPass = true;
    	return seq.Aggregate(new List<List<T>>(), (partitions, item) =>
    	{
    		bool inc = predicate(item);
    		if (inc == lastPass)
    		{
    			if (partitions.Count == 0)
    			{
    				partitions.Add(new List<T>());
    			}
    			partitions.Last().Add(item);
    		}
    		else
    		{
    			partitions.Add(new List<T> { item });
    		}
    		lastPass = inc;
    		return partitions;
    	});
    }
