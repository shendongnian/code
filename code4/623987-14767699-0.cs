    public static class Replacer
    {
        public static string Replace(string input)
        {
            return Regex.Replace(input, @"\{.+\}"), ReplaceMatchEvaluator);
        }
        private static string ReplaceMatchEvaluator(Match m)
        {
            // m.Value contains the matched portion including the braces.
            return "some string";
        }
    }
