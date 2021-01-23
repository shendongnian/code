    public static IEnumerable<ILookup<TValue, TKey>> Group<TKey, TValue>
        (List<TValue> keys,
         List<TKey> values,
         bool allowEmptyGroups = false)
    {
        var indices = new int[values.Count];
        var maxIndex = values.Count - 1;
        var nextIndex = maxIndex;
        indices[maxIndex] = -1;
        while (nextIndex >= 0)
        {
            indices[nextIndex]++;
            if (indices[nextIndex] == keys.Count)
            {
                indices[nextIndex] = 0;
                nextIndex--;
                continue;
            }
            nextIndex = maxIndex;
            if (!allowEmptyGroups && indices.Distinct().Count() != keys.Count)
            {
                continue;
            }
            yield return indices.Select((keyIndex, valueIndex) =>
                                        new
                                            {
                                                Key = keys[keyIndex],
                                                Value = values[valueIndex]
                                            })
                .OrderBy(x => x.Key)
                .ToLookup(x => x.Key, x => x.Value);
        }
    }
