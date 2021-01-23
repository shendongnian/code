    public static class Extensions
    {
        public static Boolean ToBoolean(this string str)
        {
            String cleanValue = (str ?? "").Trim();
            return
                (String.Equals(cleanValue, "true", StringComparison.OrdinalIgnoreCase)) ||
                (cleanValue != "0");
        }
    }
