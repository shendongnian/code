    public static class Extensions
    {
        public static int IndexOf<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            int index = 0;
            foreach (T item in items)
            {
                if (predicate(item))
                    break;
                index++;
            }
            return index;
        }
        public static int IndexOf<T>(this IEnumerable<T> items, T value)
        {
            int index = 0;
            foreach (T item in items)
            {
                if (item.Equals(value))
                    break;
                index++;
            }
            return index;
        }
    }
