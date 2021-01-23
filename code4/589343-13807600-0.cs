    public static SerializableDictionary<TKey, T> ToSerializableDictionary<TKey, T>(this IEnumerable<T> seq, Func<T, TKey> keySelector)
    {
    	var dict = new SerializableDictionary<TKey, T>();
    	foreach(T item in seq)
    	{
    		TKey key = keySelector(item);
    		dict.Add(key, item);
    	}
    	
    	return dict;
    }
