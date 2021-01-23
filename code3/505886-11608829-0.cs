	public class CacheList<T, P>
	{
		private Dictionary<P, T> _cacheItems = new Dictionary<P, T>();
		private Func<T, P> _getKey;
		
		public CacheList(Func<T, P> getKey)
		{
			_getKey = getKey;
		}
		
		public IList<T> GetItems()
		{
			return new List<T>(_cacheItems.Values);
		}
	
		public void Add(T item)
		{
			P key = _getKey(item);
	
			if (!_cacheItems.ContainsKey(key))
				_cacheItems.Add(key, item);
		}
	}
