    class MyCustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)  
        {  
            bool isMatchedX = IsMatchedPattern(x);
            bool isMatchedY = IsMatchedPattern(y);
    
            if (isMatchedX&& !isMatchedY ) // x matches the pattern.
            {
                return String.Compare(Strip(x), y, StringComparison.Ordinal);
            }
            if (isMatchedY && !isMatchedX) // y matches the pattern.
            {
                return String.Compare(Strip(y), x, StringComparison.Ordinal);
            }
    
            return String.Compare(x, y, StringComparison.Ordinal);
        }
        private static bool isMatchedPattern(string str)
        {
            // Use some way to return if it matches your pattern.
            // StartsWith, Contains, Regex, etc.
        }
        private static string Strip(string str)
        {
            // Use some way to return the stripped string.
            // Substring, Replace, Regex, etc.
        }
    }
