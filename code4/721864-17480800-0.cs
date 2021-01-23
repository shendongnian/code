    public static class MyExtensionMethods
    {
        public static List<T> ToListIfNotNull<T>(this IEnumerable<T> enumerable)
        {
            return (enumerable != null ? new List<T>(enumerable) : null);
        }
    }
