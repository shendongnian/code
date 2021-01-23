    public static class Test
    {
        public static bool IsSorted<T>(this IEnumerable<T> e)
        {
            return e.Zip(e.Skip(1), (a, b) => Comparer<T>.Default.Compare(a, b))
                .All(x => x <= 0);
        }
    }
    ...
    if (new[] { 1, 2, 3 }.IsSorted())
    {
        // Do something
    }
