	static class DictionaryExtensions
	{
		public static ConcurrentDictionary<K, V> ToConcurrentDictionary<K, V>(
            this IDictionary<K, V> source)
		{
			return new ConcurrentDictionary<K, V>(source);
		}
	}
