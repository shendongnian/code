    static class PathEscaper
    {
        static string invalidChars = @"""\/?:<>*|";
        static string escapeChar = "%";
        static Regex escaper = new Regex(
            "[" + Regex.Escape(escapeChar + invalidChars) + "]",
            RegexOptions.Compiled);
        static Regex unescaper = new Regex(
            Regex.Escape(escapeChar) + "([0-9A-Z]{4})",
            RegexOptions.Compiled);
        public static string Escape(string path)
        {
            return escaper.Replace(path,
                m => escapeChar + ((int)(m.Value[0])).ToString("X4"));
        }
        public static string Unescape(string path)
        {
            return unescaper.Replace(path,
                m => ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString());
        }
    }
