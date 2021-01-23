	public static IEnumerable<Tuple<T,Exception>> ForEachWithCatch<T>(this IEnumerable<T> items, Action<T> action)
	{
		var exceptions = new List<Tuple<T,Exception>>();
		
		foreach(var item in items)
		{
			try
			{
				action(item);
			}
			catch(Exception e)
			{
				exceptions.Add(Tuple.Create(item, e));
			}
		}
		
		return exceptions;
	}
