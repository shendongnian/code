	public static IEnumerable<T> 
            DistinctBy<T,TKey>(this IEnumerable<T> src, Func<T,TKey> selector)
	{
		HashSet<TKey> hs = new HashSet<TKey>();
		foreach(var item in src)
		{
			//Add returns false if item is already in set
			if(hs.Add(selector(item)))
			{
				yield return item;
			}
		}
	}
