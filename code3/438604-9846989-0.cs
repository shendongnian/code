    public static class StringExtensions
    {
        public static string[] ToStringArray(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
    
            return s.Select(x => x.ToString()).ToArray();
        }
    } 
