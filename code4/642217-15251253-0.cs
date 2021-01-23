    arr = arr.Append("JKL");
    // or
    arr = arr.Append("123", "456");
    // or
    arr = arr.Append("MNO", "PQR", "STU", "VWY", "etc", "...");
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append(
            this IEnumerable<T> source, params T[] tail)
        {
            return source.Concat(tail);
        }
    }
