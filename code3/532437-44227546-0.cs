    public static class ObjectExtensions
    {
        public static string EmptyIfNull(this object value)
        {
            return value?.ToString() ?? string.Empty;
        }
    }
