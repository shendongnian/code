    private static void AddIfNotNull<K,T>(
        this IDictionary<K,T> myDictionary
    ,   K key
    ,   T value) {
        if (value != default(T) {
            myDictionary.Add(key, value);
        }
    }
    myDictionary.AddIfNotNull(myDictionary, "...", myObject.whatever);
