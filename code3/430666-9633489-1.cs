    public static class StringExtensions
    {
        public static string ValueOrEmpty(this object obj)
        {
            return obj == null ? "" : obj.ToString();
        }
    }
