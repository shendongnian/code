        public static IEnumerable<TSource> ForEach<TSource>(this System.Collections.Generic.IEnumerable<TSource> source, Action<TSource> action)
        {
            ThrowIfNull(source, "source");
            ThrowIfNull(action, "action");
            foreach (TSource item in source)
            {
                action(item);
            }
            return source;
        }
        public static IEnumerable<TSource> ForEach<TSource>(this System.Collections.Generic.IEnumerable<TSource> source, Action<TSource, int> action)
        {
            ThrowIfNull(source, "source");
            ThrowIfNull(action, "action");
            int index = 0;
            foreach (TSource item in source)
            {
                action(item, index);
                index++;
            }
            return source;
        }
