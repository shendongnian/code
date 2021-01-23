        public static IEnumerable<T> ExceptSingle<T>(this IEnumerable<T> source, T valueToRemove)
        {
            return source
                .GroupBy(s => s)
                .SelectMany(g => g.Key.Equals(valueToRemove) ? g.Skip(1) : g);
        }
