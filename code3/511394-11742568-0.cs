    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string s)
        {
            return (T)Enum.Parse(typeof(T), s);
        }
    }
