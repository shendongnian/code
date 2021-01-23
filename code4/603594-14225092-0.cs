    public static class StringExtensions
    {
        public static string ReplaceBetweenQuotes(this string str, string replacement)
        {
            if (str.Count(c => c.Equals('"')) == 2)
            {
                int start = str.IndexOf('"') + 1;
                str = str.Replace(str.Substring(start, str.LastIndexOf('"') - start), replacement);
            }
            return str;
        }
    }
