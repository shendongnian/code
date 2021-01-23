    class ListUtil
    {
        public static List<T> ConvertToList<T>(this IEnumerable items)
        {
            // see method above
            return items.ConvertTo<T>().ToList();
        }
        public static IList ConvertToList(this IEnumerable items, Type targetType)
        {
            var method = typeof(ListUtil).GetMethod(
                "ConvertToList", 
                new[] { typeof(IEnumerable) });
            var generic = method.MakeGenericMethod(targetType);
            return (IList)generic.Invoke(null, new[] { items });
        }
    }
