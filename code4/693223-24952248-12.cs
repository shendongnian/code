	public static class Extensions
	{
		public static IEnumerable<T> MyDistinct<T, V>(this IEnumerable<T> query,
														Func<T, V> f, 
														Func<IGrouping<V,T>,T> h=null)
		{
			if (h==null) h=(x => x.First());
			return query.GroupBy(f).Select(h);
		}
	}
