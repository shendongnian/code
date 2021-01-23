    public static async Task<IEnumerable<T>> TakeWhileAsync<T>(this IEnumerable<Task<T>> tasks, Func<T, bool> predicate)
	{
		var results = new List<T>();
		
		foreach (var task in tasks)
		{
			var result = await task;
			if (!predicate(result))
				break;
			
			results.Add(result);
		}
		return results;
	}
