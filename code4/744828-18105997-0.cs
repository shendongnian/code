    public static class Extensions
    {
        public static bool IsIn<T>(this T source, params T[] values)
        {
            return values.Contains(source);
        }
    }
