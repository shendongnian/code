    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this s)
        {
            return s == null || s.Length == 0;
        }
    }
