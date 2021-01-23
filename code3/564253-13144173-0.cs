    class WrappedInt { public int Value; }
    Dictionary<TKey, WrappedInt> dictionary = ...;
    foreach (var wrappedVal in dictionary.Values)
    {
        wrappedVal.Value *= 3;
    }
    // or 
    foreach (var wrappedVal in dictionary)
    {
        wrappedVal.Value.Value *= 3;
    }
