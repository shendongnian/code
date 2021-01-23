    public static Task ForEachAsync<T>(IEnumerable<T> items, Action<T> action)
    {
        return Task.Factory.StartNew(() =>
        {
            foreach (T item in items)
            {
                action(item);
            }
        });
    }
