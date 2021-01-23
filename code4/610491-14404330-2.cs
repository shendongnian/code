    public class NoopOrder<T> : IOrderedEnumerable<T>
    {
        private IQueryable<T> source;
        public NoopOrder(IQueryable<T> source)
        {
            this.source = source;
        }
    
        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return new NoopOrder<T>(source);
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return source.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return source.GetEnumerator();
        }
    }
