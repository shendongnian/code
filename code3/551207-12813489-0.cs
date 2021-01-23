    var finalList = NewCustomers.UnionBy(OldCustomers, c => c.CustomerID).ToList();
-
    public static class SOExtension
    {
        public static IEnumerable<T> UnionBy<T,V>(this IEnumerable<T> list, IEnumerable<T> otherList,Func<T,V> selector)
        {
            HashSet<V> set = new HashSet<V>();
            foreach (T t in list)
            {
                set.Add(selector(t));
                yield return t;
            }
            foreach(T t in otherList)
            {
                if(!set.Contains(selector(t)))
                    yield return t;
            }
        }
    }
