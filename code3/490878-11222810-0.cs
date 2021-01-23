    static class StringExtensions
    {
        public static string PossiblyToUpper(this string s)
        {
            if (s != null)
                return s.ToUpper();
            return null;
        }
    }
