    public static class ListExtensions
	{
		public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> range)
		{
			foreach (var r in range)
			{
				list.Add(r);
			}
			return list;
		}
	}
