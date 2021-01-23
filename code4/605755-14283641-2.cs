    public class MultiKeyDictionary<TValue> 
	{
		private Dictionary<Guid, TValue> values;
		private Dictionary<Object, Guid> keys;
		
		public MultiKeyDictionary()
		{
			keys = new Dictionary<Object,Guid>();
			values = new Dictionary<Guid,TValue>();
		}
		public IEnumerable<Object> Keys
		{
			get { return keys.Keys.AsEnumerable();} // May group according to values here
		}
		
		public IEnumerable<TValue> Values
		{
			get { return values.Values;}
		}
		
		public TValue this[object key]
		{
			get 
			{
				if (keys.ContainsKey(key)) 
				{
					var internalKey = keys[key];
					return values[internalKey];
				}
				throw new KeyNotFoundException();
			}
		}
		
		
		public void Add(TValue value,object key1, params object[] keys) // key1 to force minimum 1 key
		{
			Add(key1 , value);
			foreach( var key in keys)
			{
			Add (key, value);
			}
		}
	
		private void Add(Object key, TValue value)
		{
			var internalKey = Guid.NewGuid();
			keys.Add( key, internalKey);
			values.Add(internalKey, value);		
		}	
	}
