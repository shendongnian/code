        private static List<string> ExtractFromString(string source, string start, string end)
        {
            var results = new List<string>();
            string pattern = string.Format(
                "{0}({1}){2}", 
                Regex.Escape(start), 
                ".+?", 
                 Regex.Escape(end));
            foreach (var m in Regex.Matches(source, pattern))
            {
                results.Add(m.Groups[1].Value);
            }
            return results;
        }
