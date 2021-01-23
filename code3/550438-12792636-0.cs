    static class StringExtensions 
    {
        public static string RemoveExtraHypen(this string str) 
        {
            return string.Join("-", str.Split(new []{'-'}, StringSplitOptions.RemoveEmptyEntries));
        }
    }
