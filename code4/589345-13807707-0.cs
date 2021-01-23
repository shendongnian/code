    public static SerializableDictionary<TKey, T> ToSerializableDictionary<TKey, T>(this IEnumerable<T> seq, Func<T, TKey> keySelector)
    {
        var dict = seq.ToDictionary(keySelector);
        
        //since SerializableDictionary can accept an IDictionary
        return new SerializableDictionary<TKey, T>(dict);
        
    }
