    public static class EnumUtil
    {
        public static IEnumerable<T> GetEnumValuesFor<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
