    public static class StringCleaner
    {    
        public static Regex invalidChars = new Regex(@"[^A-Z0-9._\-]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static string ReplaceInvalidChars(string input)
        {
            return invalidChars.Replace(input, "_");
        }
    }
