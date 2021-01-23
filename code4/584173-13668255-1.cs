    public static class LinqExtensions
    {
        public static Type GetElementType(this IEnumerable source)
        {
            var enumerableType = source.GetType();
            if (enumerableType.IsArray)
            {
                return enumerableType.GetElementType();
            }
            if (enumerableType.IsGenericType)
            {
                return enumerableType.GetGenericArguments().First();
            }
            return null;
        }
    }
