    public static class Extension
    {
        public static bool IsNumeric(this string s)
        {
            int output;
            return int.TryParse(s, out output);
        }
    }
