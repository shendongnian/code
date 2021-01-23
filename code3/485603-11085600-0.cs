    public class AtomicList<T> : IEnumerable<T>
    {
        private List<T> InternalCollection = new List<T>();
    
        public void Add(T Value)
        {
            List<T> Update = new List<T>(InternalCollection);
            Update.Add(Value);
            Interlocked.Exchange(ref InternalCollection, Update);
        }
    
        public void Remove(T Value)
        {
            List<T> Update = new List<T>(InternalCollection);
            Update.Remove(Value);
            Interlocked.Exchange(ref InternalCollection, Update);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            ...
