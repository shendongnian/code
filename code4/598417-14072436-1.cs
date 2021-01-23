        private static MatchCollection GetSpecialTables(string inputStr, string ftrName)
        {
            try
            {
                return Regex.Matches(inputStr, string.Format(@"<table>\s+<tr><td>{0}</td>.+?</table>", Regex.Escape(ftrName)), RegexOptions.Singleline);
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression, handle it
                return null;
            }
        }
        // use it this way!
        static void Main()
        {
            var matches = GetSpecialTables(myHtml, "Total");
            foreach (Match match in matches)
            {
                // match.Value;
            }
        }
