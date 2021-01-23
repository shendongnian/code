	public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
	{
		List<T> temp = new List<T>();
		foreach (T item in source)
		{
			temp.Add(item);
			if (temp.Count == batchSize)
			{
				yield return temp.Select(n => n);
				temp.Clear();
			}
		}
		if (temp.Any())
		{
			yield return temp.Select(n => n);
		}
	}
