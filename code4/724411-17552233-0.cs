	public class CachedLoader<K, T> : Dictionary<K, T>
	{
		private Func<K,T> GetItem = null;
		public CachedLoader(Func<K,T> getItem)
		{
			this.GetItem = getItem;
		}
		public new T this[K key]
		{
			get
			{
				if (!base.ContainsKey(key)) base[key] = GetItem(key);
				return base[key];
			}
		}
	}
