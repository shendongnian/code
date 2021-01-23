	public static IEnumerable<TSource> OrderBy<TSource, TKey>(
		IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		var items = source.ToArray();
		var keys = items.Select(keySelector).ToArray();
		Array.Sort(keys, items);
		foreach (var item in items)
		{
			yield return item;
		}
	}
