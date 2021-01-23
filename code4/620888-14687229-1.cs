    public static class IEnumerableExtensions
    {
        public static bool IsLast<T>(this IEnumerable<T> items, T item)
        {
            var last =  items.LastOrDefault();
            if (last == null)
                return false;
            return item.Equals(last); // OR Object.ReferenceEquals(last, item)
        }
        public static bool IsFirst<T>(this IEnumerable<T> items, T item)
        {
            var first =  items.FirstOrDefault();
            if (first == null)
                return false;
            return item.Equals(first);
        }
        public static bool IsFirstOrLast<T>(this IEnumerable<T> items, T item)
        {
            return items.IsFirst(item) || items.IsLast(item);
        }
     }
