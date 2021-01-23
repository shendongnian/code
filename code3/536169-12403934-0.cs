	public class CacheItem
	{
		public void ExpensiveLoad()
		{
			// some expensive code
		}
	}
	public class Cache
	{
		private static object _SynchObj = new object();
		private static Dictionary<string, CacheItem> _Cache = new Dictionary<string, CacheItem>();
		private static ReadOnlyCollection<string> _CacheKeysReadOnly = new ReadOnlyCollection(new List<string>());
		
		public IList<string> CacheKeys
		{
			get
			{
				return _CacheKeysReadOnly;
			}
		}
		public CacheItem Get(string key)
		{
			CacheItem item = null;
			ReadOnlyCollection<string> keys = _CacheKeysReadOnly;
			if (!keys.Contains(key))
			{
				lock (_SynchObj)
				{
					keys = _CacheKeysReadOnly;
					if (!keys.Contains(key))
					{
						item = new CacheItem();
						item.ExpensiveLoad();
						_Cache.Add(key, item);
						List<string> newKeys = new List<string>(_CacheKeysReadOnly);
						newKeys.Add(key);
						_CacheKeysReadOnly = newKeys.AsReadOnly();
					}
				}
			}
			return item;
		}
	}
