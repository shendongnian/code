    public class UniDirectionalMergeFixListener : DefaultMergeEventListener
    {
        protected override IDictionary GetMergeMap(object anything)
        {
            var cache = (EventCache)anything;
            var result = IdentityMap.Instantiate(cache.Count);
            foreach (DictionaryEntry entry in cache)
                result[entry.Value] = entry.Key;
            return result;
        }
    }
