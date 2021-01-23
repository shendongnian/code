    static class ArrayExtensions
    {
        public static void ReplaceAll<T>(this T[] items, T oldValue, T newValue)
        {
            for (int index = 0; index < items.Length; index++)
                if (items[index].Equals(oldValue))
                    items[index] = newValue;
        }
    }
