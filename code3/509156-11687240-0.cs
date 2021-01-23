    public static class Extensions
    {
        public static IEnumerable<Tuple<T,T>> CartesianProduct<T>(
                this IEnumerable<T> source,
                IEnumerable<T> multiplier)
        {
            return source.SelectMany(s => multiplier, (s, m) => Tuple.Create(s, m));   
        }
    }
