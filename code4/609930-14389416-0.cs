    public static class StringExtensions
    {
        public static String ToNullString(this object o)
        {
            return o == null ? "" : o.ToString();
        }
    }
