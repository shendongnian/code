    public static class Extensions
    {
        public static IEnumerable<TResult> CartesianProduct<T, TResult>(
                this IEnumerable<T> source,
                IEnumerable<T> multiplier,
                Func<T, T, TResult> combiner)
        {
            return source.SelectMany(s => multiplier, (s, m) => combiner(s, m));   
        }
    }
