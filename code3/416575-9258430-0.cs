    public class CachedEnumerable<T> : IEnumerable<T>
    {
        public CachedEnumerable<T>(IEnumerable<T> enumerable)
        {
            result = new Lazy<List<T>>(() => enumerable.ToList());
        }
    
        private Lazy<List<T>> result;
    
        public IEnumerator<T> GetEnumerator()
        {
            return this.result.Value.GetEnumerator();
        }
    
        System.Collections.IEnumerable GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
