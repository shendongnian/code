    public static class Enum<T>
    {
        public static bool IsDefined(string name)
        {
            return Enum.IsDefined(typeof(T), name);
        }
        public static bool IsDefined(T value)
        {
            return Enum.IsDefined(typeof(T), value);
        }
        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        // etc
    }
