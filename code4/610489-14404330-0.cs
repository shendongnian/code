    public class NoopOrder<T> : IOrderedEnumerable<T>
    {
        private IQueryable<T> source;
        public NoopOrder(IQueryable<T> source)
        {
            this.source = source;
        }
    
        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            if (descending)
            {
                return source.OrderByDescending(keySelector, comparer);
            }
            else
            {
                return source.OrderBy(keySelector, comparer);
            }
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
