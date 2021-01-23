    public static class DictionaryExtension
	{
		public static TValue GetValueOrDefault<TKey, TValue>
			(	this IDictionary<TKey, TValue> dictionary,TKey key)
		{
			TValue value;
			return dictionary.TryGetValue(key, out value) ? value : default(TValue);
		}
	}
