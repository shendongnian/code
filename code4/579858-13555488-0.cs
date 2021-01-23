    public static class StringExtensions
    {
        public static string MySubstring(this string s, string start, string end)
        {
            int startI = s.IndexOf(start);
            int endI = s.IndexOf(end, startI);
            return s.Substring(startI, endI - startI + 1);
        }
    }
