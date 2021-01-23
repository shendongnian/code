    public static class Extensions
    {
        public static string NullToString(this object value)
        {
            if (value == null)
                return "";
            return value.ToString();
        }
    }
