	public static class DictionaryExtensions 
	{
		public static IDictionary<TValue,List<TKey>> Reverse<TKey,TValue>(this IDictionary<TKey,TValue> src) 
		{
			var result = new Dictionary<TValue,List<TKey>>();
			
			foreach (var pair in src) 
			{
				List<TKey> keyList;
				
				if (!result.TryGetValue(pair.Value, out keyList)) 
				{
					keyList = new List<TKey>();
					result[pair.Value] = keyList;
				}
				
				keyList.Add(pair.Key);
			}
			
			return result;
		}
	}
