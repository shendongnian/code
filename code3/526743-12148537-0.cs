    public class MySorterClass
    {
        public IEnumerable<TSource> OrderList<TSource, TKey>(IEnumerable<TSource> list, Func<TSource, TKey> selector)
        {
            return list.OrderBy(selector);
        }
    
        public IEnumerable<TSource> OrderList<TSource>(IEnumerable<TSource> list, string propertyName)
        {
            return list.OrderBy(propertyName);
        }
    }
