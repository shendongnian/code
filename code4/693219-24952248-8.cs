	public static class Extensions
	{
		public static IEnumerable<T> MyDistinct<T, V>(this IEnumerable<T> query, 
														Func<T, V> f)
		{
			return query.GroupBy(f).Select(x=>x.First());
		}
	}
