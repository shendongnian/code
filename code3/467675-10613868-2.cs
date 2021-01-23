    public static void ForEachWithIndex<T>(this IEnumerable<T> enu,
                               Action<T, int> action, Func<T, int, bool> condition)
    {
        int i = 0;
        foreach (T item in enu)
        {
            if (condition(item, i))
            {
                action(item, i);
            }
            ++i;
        }
    }
