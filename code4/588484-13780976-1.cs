    public static class StringExtensionMethods
    {
        public static List<string> EverythingBetween(this string source, string start, string end)
        {
            var results = new List<string>();
            string pattern = string.Format(
                "{0}{1}{2}",
                Regex.Escape(start),
                ".+?",
                 Regex.Escape(end));
            foreach (var Match in Regex.Matches(source, pattern))
            {
                string result = Match.ToString();
                results.Add(result.Substring(start.Length, result.Length - start.Length - end.Length));
            }
            return results;
        }
    }
