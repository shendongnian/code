    public static class BooleanParser
    {
        public static bool SafeParse(string value)
        {
            var s = (value ?? "").Trim().ToLower();
            return s == "true" || s == "1";
        }
    }
