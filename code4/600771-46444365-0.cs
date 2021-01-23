    public static class IEnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> data, Action<T> action)
        {
            foreach (T d in data)
            {
                action(d);
            }
        }
    }
