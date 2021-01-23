    	public static IEnumerable<IEnumerable<T>> SplitList<T>(this IEnumerable<T> source, int maxPerList)
		{
			var enumerable = source as IList<T> ?? source.ToList();
			if (!enumerable.Any())
			{
				return new List<IEnumerable<T>>();
			}
			return (new List<IEnumerable<T>>() { enumerable.Take(maxPerList) }).Concat(enumerable.Skip(maxPerList).SplitList<T>(maxPerList));
		}
