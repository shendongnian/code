   	public static bool AllEqual<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));
		comparer = comparer ?? EqualityComparer<T>.Default;
		using (var enumerator = source.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				var value = enumerator.Current;
				while (enumerator.MoveNext())
				{
					if (!comparer.Equals(enumerator.Current, value))
						return false;
				}
			}
			return true;
		}
	}
