	public static IEnumerable<TItem> Extend<TItem>(
                this IEnumerable<TItem> source, 
                int n, 
                Func<TItem> with) 
	{
		return source.Concat(
			from i in Enumerable.Range(0, n) select with()
		).Take(n);
	}
	
	public static IEnumerable<TItem> Extend<TItem>(
                this IEnumerable<TItem> source, 
                int n, 
                TItem with = default(TItem)) 
	{
		return source.Extend(n, with: () => with);
	}
