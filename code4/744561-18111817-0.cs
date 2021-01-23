    public static class Extensions
    {
        public static IEnumerable<T> SkipAt<T>(this IEnumerable<T> source, int index)
        {
            return source.Where((it, i) => i != index);
        }
    }
