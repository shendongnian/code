    public static class StringHelper
    {
        //Truncates a string to be no longer than a certain length
        public static string TruncateWithEllipsis(string s, int length)
        {
            //there may be a more appropiate unicode character for this
            const string Ellipsis = "...";
    
            if (Ellipsis.Length > length)
                throw new ArgumentOutOfRangeException("length", length, "length must be at least as long as ellipsis.");
    
            if (s.Length > length)
                return s.Substring(0, length - Ellipsis.Length) + Ellipsis;
            else
                return s;
        }
    }
