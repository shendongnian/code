    public static class Extensions
    {
        public static bool InsensitiveEqual(this string val1, string val2)
        {
            return val1.Equals(val2, StringComparison.OrdinalIgnoreCase);
        }
    }
