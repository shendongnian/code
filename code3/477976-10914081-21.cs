    public static IEnumerable<Tuple<TKey[], IEnumerable<TValue>>> GroupBoth<TKey, TValue>
        (List<TKey> keys,
         List<TValue> values)
    {
        foreach (var tuple in
            Group(keys, values).SelectMany(group => group
                .Select(s => Tuple.Create(new[] {s.Key}, s.Where(x => true)))))
        {
            yield return tuple;
        }
        foreach (var tuple in
            GroupCombined(keys, values).SelectMany(group => group
                .Select(s => Tuple.Create(s.Key, s.Where(x => true)))))
        {
            yield return tuple;
        }
    }
