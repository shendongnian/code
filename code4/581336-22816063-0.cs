    public static class DictionaryExtensions
        {
            public static IReadOnlyDictionary<TKey, IEnumerable<TValue>> ToReadOnlyDictionary<TKey, TValue>(
                this IDictionary<TKey, List<TValue>> toWrap)
            {
                var intermediate = toWrap.ToDictionary(a => a.Key, a =>a.Value!=null? a.Value.ToArray().AsEnumerable():null);
                var wrapper = new ReadOnlyDictionary<TKey, IEnumerable<TValue>>(intermediate);
                return wrapper;
            }   
        }
