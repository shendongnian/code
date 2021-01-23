    public static void Join<T>(this IEnumerable<T> e, string separator, Action<T, string> action)
    {
        using (var t = e.GetEnumerator())
        {
            if (!t.MoveNext())
                return;
            for (;;)
            {
                T current = t.Current;
                bool last = !t.MoveNext();
                action(current, last ? "" : separator);
                if (last)
                    break;
            }
        }
    }
