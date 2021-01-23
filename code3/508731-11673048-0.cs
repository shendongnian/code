    public static class ListExtensions
    {
        public static void SetLast<T>(this IList<T> source, T value)
        {
            source[source.Count - 1] = value;
        }
    }
