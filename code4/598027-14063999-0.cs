    class MyCustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)  
        {  
            bool isAvgX = IsAvg(x);
            bool isAvgY = IsAvg(y);
    
            if (isAvgX || isAvgY)
            {
                // If one of the strings is not an " (avg) ..." string
                // use a custom comparison
                if (!isAvgY) // x is the average string.
                {
                    string strippedX = Strip(x);
    
                    if (String.Equals(strippedX, y, StringComparison.Ordinal))
                        return 1;
                }
                if (!isAvgX) // y is the average string.
                {
                    string strippedY = Strip(y);
    
                    if (String.Equals(strippedY, x, StringComparison.Ordinal))
                        return -1;
                }
            }
    
            return String.Compare(x, y, StringComparison.Ordinal);
        }
        private static bool IsAvg(string str)
        {
            // Use some way to return if it is avg.
            // StartsWith, Contains, Regex, etc.
        }
        private static string Strip(string str)
        {
            // Use some way to return the stripped string.
            // Substring, Replace, Regex, etc.
        }
    }
