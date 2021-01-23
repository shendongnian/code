    public static class LastEnumerator
	{
		public static IEnumerable<MetaEnumerableItem<T>> GetLastEnumerable<T>(this IEnumerable<T> blah)
		{
			bool isFirst = true;
			using (var enumerator = blah.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					bool isLast;
					do
					{
						var current = enumerator.Current;
						isLast = !enumerator.MoveNext();
						yield return new MetaEnumerableItem<T>
							{
								Value = current,
								IsLast = isLast,
								IsFirst = isFirst
							};
						isFirst = false;
					} while (!isLast);
				}
			}
		}
	}
	public class MetaEnumerableItem<T>
	{
		public T Value { get; set; }
		public bool IsLast { get; set; }
		public bool IsFirst { get; set; }
	}
