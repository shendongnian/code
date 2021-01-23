        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            if (action == null)
                throw new ArgumentNullException("action");
            foreach (var e in enumerable)
            {
                action(e);
            }
        }
