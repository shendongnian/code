    public static class Enum<T>
    {
        public static bool IsDefined(object value)
        {
            return Enum.IsDefined(typeof(T), value);
        }
        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        // etc
    }
