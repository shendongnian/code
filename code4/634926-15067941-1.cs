    public static class IListExtensions
    {
        public static bool ContainsAny<T>(this IList<T> list, IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                if (list.Contains(item))
                    return true;
            }
            return false;
        }
    }
