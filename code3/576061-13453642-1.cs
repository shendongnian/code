    using MyDict = ConcurrentDictionary<Tuple<string, string, string>, SomeObject>;
    MyDict Merge(IEnumerable<MyDict> dicts)
    {
        MyDict result = new MyDict();
        foreach (var dict in dicts)
        {
            foreach (var kvp in dict)
            {
                result.AddOrUpdate(
                    kvp.Key,        // If the key does not exist, add the value;
                    kvp.Value,      // otherwise, combine the two values.
                    (key, value) => Combine(value, kvp.Value)
                );
            }
        }
        return result;
    }
