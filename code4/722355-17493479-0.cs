    public static class Extensions
    {
        public static int Count<T>(this IOrderedEnumerable<T> ordered)
        {
            // you can check if ordered is of type OrderedEnumerable<T>
            Type type = ordered.GetType();
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var field = type.GetField("source", flags);
            var source = field.GetValue(ordered);
            if (source is ICollection<T>)
                return ((ICollection<T>)source).Count;
            return ordered.Count();
        }
    }
