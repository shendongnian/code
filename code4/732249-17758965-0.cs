    class ListUtil
    {
        public static List<T> ConvertToList<T>(this IEnumerable items)
        {
            // see method above
            return sourceList.ConvertTo<T>().ToList();
        }
        public static IList ConvertToList(this IEnumerable items, Type targetType)
        {
            var method = typeof(ListUtil).GetMethod("ConvertToList", typeof(IEnumerable));
            var generic = method.MakeGenericMethod(targetType);
            return generic.Invoke(null, new[] { items });
        }
    }
