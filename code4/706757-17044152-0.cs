    public static class StringExtensions {
        public static WhiteSpaceRegex = new Regex(@"\s*");
        public static string WithoutWhitespace(this string input) 
        {
            return WhiteSpaceRegex.Replace(input, string.Empty);
        }
    }
