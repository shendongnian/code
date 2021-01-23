        public static string[] getPclCodes(string line, out MatchCollection codes)
        {
            string pattern = "\\x1B.*?H";
            Regex regex = new Regex(pattern);
            codes = regex.Matches(line);
            string[] pclCodes = Regex.Split(line, pattern);
            return pclCodes;
        }
