    public static IEnumerable<T> SingleEnumeration<T>(this IEnumerable<T> source)
    {
        return new SingleEnumerator<T>(source);
    }
    
    private class SingleEnumerator<T> : IEnumerable<T>
    {
        private IEnumerable<T> sequence;
        private Guid guid;
        public SingleEnumerator(IEnumerable<T> sequence)
        {
            this.guid = Guid.NewGuid();
            this.sequence = sequence;
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return sequence.CachedSequence(guid.ToString()).GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return sequence.CachedSequence(guid.ToString()).GetEnumerator();
        }
    }
    
    private static Dictionary<string, object> cache = new Dictionary<string, object>();
    public static IEnumerable<T> CachedSequence<T>(this IEnumerable<T> source, string key)
    {
        object value;
        if (cache.TryGetValue(key, out value))
        {
            return (List<T>)value;
        }
        else
        {
            return iterateSequence(source, key);
        }
    }
    
    private static IEnumerable<T> iterateSequence<T>(IEnumerable<T> source, string key)
    {
        List<T> list = new List<T>();
        foreach (T item in source)
        {
            list.Add(item);
            yield return item;
        }
        cache.Add(key, list);
    }
