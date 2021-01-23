    public static class ArrayExtensions
    {
        public static T ElementOrDefault<T>(this T[] array, int index)
        {
            return ElementOrDefault(array, index, default(T));
        }
        public static T ElementOrDefault<T>(this T[] array, int index, T defaultValue)
        {
            return index < array.Length ? array[index] : defaultValue;
        }
    }
