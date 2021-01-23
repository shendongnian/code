    public static class DictionaryExtensions
    {
        public static IEnumerable<DictionaryDifference<TKey, TValue>> GetDifferencesFrom<TKey, TValue>(
            this IDictionary<TKey, TValue> original,
            IDictionary<TKey, TValue> latest)
            where TValue : IComparable
        {
            foreach (var originalItem in original)
            {
                if (latest.ContainsKey(originalItem.Key))
                {
                    if (originalItem.Value.CompareTo(latest[originalItem.Key]) != 0)
                    {
                        // The key is in the latest but the value is different.
                        yield return new DictionaryDifference<TKey, TValue>
                        {
                            Key = originalItem.Key,
                            OriginalValue = originalItem.Value,
                            NewValue = latest[originalItem.Key]
                        };
                    }
                }
                else
                {
                    // The key is not in the latest dictionary.
                    yield return new DictionaryDifference<TKey, TValue>
                    {
                        Key = originalItem.Key,
                        OriginalValue = originalItem.Value,
                        NewValue = default(TValue)
                    };
                }
            }
            foreach (var newItem in latest)
            {
                if (!original.ContainsKey(newItem.Key))
                {
                    // The key is not in the original dictionary.
                    yield return new DictionaryDifference<TKey, TValue>
                    {
                        Key = newItem.Key,
                        OriginalValue = default(TValue),
                        NewValue = latest[newItem.Key]
                    };
                }
            }
        }
    }
