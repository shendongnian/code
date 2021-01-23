    public static class CollectionExtension
    {
        public static void AddUniqueItem<T>(this List<T> list, T item, bool throwException)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }
            else if(throwException)
            {
                throw new InvalidOperationException("Item already exists in the list");
            }
        }
        public static bool IsUnique<T>(this List<T> list, IEqualityComparer<T> comparer)
        {
            return list.Count == list.Distinct(comparer).Count();
        }
        public static bool IsUnique<T>(this List<T> list)
        {
            return list.Count == list.Distinct().Count();
        }
    }
