    public static class MyEnumerable
    {
        public static IEnumerable<T> Concat<T, T1, T2>(this IEnumerable<T1> source, this IEnumerable<T2> other)
            where T1 : T
            where T2 : T
        {
            return source.Cast<T>().Concat(other.Cast<T>());
        }
    }
