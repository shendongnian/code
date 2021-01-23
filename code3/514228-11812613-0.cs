    public static class Extension
    {
        public static bool EqualsAny(this string item, params string[] array)
        {
            return array.Any(s => item.ToUpper() == s.ToUpper());
        }
    }
