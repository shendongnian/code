    public static class LinqExtension
    {
        public static bool ContainsAny<TInput>(this IEnumerable<TInput> @this, IList<TInput> items)
        {
            return @this.Any(items.Contains);
        }
    }
