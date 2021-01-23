    public static class ArrayExtensions
    {
        public static bool TryIndex<T>(this T[] array, int index, out T result)
        {
            index = Math.Abs(index);
            result = default(T);
            bool success = false;
    
            if (array != null && index < array.Length)
            {
                result = (T)array.GetValue(index);
                success = true;
            }
    
            return success;
        }
    }
