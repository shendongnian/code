    public static void DoActionForEachElement<T>(IEnumerable<T> items, Func<T, bool> predicate, Action<T> action)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                    action(item);
            }
        }
    }
