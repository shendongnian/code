	public static class ICollectionExtensions
	{
		public static void ForEach(this ICollection<T> collection, Action<T> action)
		{
			var list = collection as List<T>;
			if(list==null)
				collection.ToList().ForEach(action);
			else
				list.ForEach(action);
		}
	}
