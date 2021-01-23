    public static class Extensions
    {
        public static bool IsNull<T>(this T source) where T : class
        {
            return source == null;
        }
    }
