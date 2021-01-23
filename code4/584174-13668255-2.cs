    public static class SortingExtensions
    {
        public static IEnumerable<T> CustomSort<T>(this IEnumerable<T> source, string sortProperties)
        {
            // sort here
        }
        public static IEnumerable CustomSort(this IEnumerable source, string sortProperties)
        {
            var elementType = source.GetElementType();
            var genericElementType = typeof (IEnumerable<>).MakeGenericType(elementType);
            var sortMethod = typeof (SortingExtensions).GetMethod(
                "CustomSort", 
                BindingFlags.Public | BindingFlags.Static,
                null, 
                new [] {genericElementType, typeof (string)},
                null);
            return (IEnumerable) sortMethod.Invoke(null, new object[] {source, sortProperties});
        }
    }
