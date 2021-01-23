    public static class StringExtensions
    {
        public static string ReplaceString(this string s, string newString)
        {
            int startIndex = s.IndexOf("<");
            s = s.Insert(startIndex, newString);
            startIndex = s.IndexOf("<"); //redetermine the startIndex in a new string generated above
            int length = s.IndexOf(">") - startIndex + 1;
            return s.Remove(startIndex, length);
        }
    }
