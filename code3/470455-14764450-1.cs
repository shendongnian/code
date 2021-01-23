	public static IEnumerable<TSource> OrderByThenBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> orderBy, Func<TSource, TKey> thenBy)
	{
		var sorted = source
			.Select(s => new Tuple<TSource, TKey>(s, orderBy(s)))
			.OrderBy(s => s.Item2)
			.GroupBy(s => s.Item2);
		var result = new List<TSource>();
		foreach (var s in sorted)
		{
			if (s.Count() > 1)
				result.AddRange(s.Select(p => p.Item1).OrderBy(thenBy));
			else
				result.Add(s.First().Item1);
		}
		return result;
	}
