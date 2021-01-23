	static class DictionaryHelper
	{
		public static TValue TryGetValue<TKey, TValue>(
			Dictionary<TKey, TValue> dict, TKey value, out bool found)
		{
			TValue result;
			found = dict.TryGetValue(value, out result);
			return result;
		}
	}
