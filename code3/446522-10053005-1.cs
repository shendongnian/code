	public static class MyLinq
	{
		public static IDictionary<TKey, TValue> ToDict<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> t)
		{
			return t.ToDictionary(p => p.Key, p => p.Value);
		}
	}
