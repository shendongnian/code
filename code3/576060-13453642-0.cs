    using MyDict = ConcurrentDictionary<Tuple<string, string, string>, SomeObject>;
    MyDict Merge(IEnumerable<MyDict> dicts)
    {
        MyDict result = new MyDict();
        foreach (var dict in dicts)
        {
            foreach (var kvp in dict)
            {
                result.AddOrUpdate(kvp.Key, kvp.Value, (key, oldValue) => oldValue);
                // -- or --
                result.AddOrUpdate(kvp.Key, kvp.Value, (key, oldValue) => kvp.Value);
            }
        }
        return result;
    }
