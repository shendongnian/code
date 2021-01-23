	static class Ex
	{
		public static IEnumerable<T> MergeLeft<T>
			(this IEnumerable<IEnumerable<T>> cols) where T:class
		{
			return cols
				.Aggregate(
					Enumerable.Empty<T>(),
					(acc,col) => 
					acc
						.Concat(Infinite<T>(null))
						.Zip(col, (a, b) => a ?? b));	
		}
		private static IEnumerable<T> Infinite<T>(T item)
		{
			for(;;){yield return item;}
		}
	}
