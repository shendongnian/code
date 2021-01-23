    public static class EnumExtensions
    {
        public static string GetEnumName<T>(this T value) where T : struct
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new InvalidOperationException(string.Format("{0} is not an enum", type));
            return type.GetEnumName(value);
        }
    }
