    Parallel.ForEach(cache.Keys, key =>
    {
        if(key.IndexOf(tableName, StringComparison.Ordinal) >= 0)
        {
            dynamic value; // just because I don't know your dictionary.
            cache.TryRemove(key, out value);
        }
    });
