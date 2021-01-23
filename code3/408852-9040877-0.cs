	public class HybridLookup<TKey, TValue> : IEnumerable<TValue>
	{
		private readonly IDictionary<TKey, TValue> _storage;
		public HybridLookup()
		{
			_storage = new Dictionary<TKey, TValue>();
		}
		public TValue this[TKey key]
		{
			get { return _storage[key]; }
		}
		public Boolean Contains(TKey key)
		{
			return _storage.ContainsKey(key);
		}
		public IEnumerator<TValue> GetEnumerator()
		{
			return _storage.Values.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
