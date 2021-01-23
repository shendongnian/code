    static class ArrayExtensions
    {
        public static void ReplaceAll<T>(this T[] items, T oldValue, T newValue)
        {
            items.ReplaceAll(oldValue, newValue, EqualityComparer<T>.Default);
        }
        public static void ReplaceAll<T>(this T[] items, T oldValue, T newValue, IEqualityComparer<T> comparer)
        {
            for (int index = 0; index < items.Length; index++)
                if (comparer.Equals(items[index], oldValue))
                    items[index] = newValue;
        }
    }
