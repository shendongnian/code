    public static class Replacer
    {
        public static string Replace(string input)
        {
            return Regex.Replace(input, @"\{(?P<value0>.+)#(?<value1>.+)/(?<value2>.+)\}"), ReplaceMatchEvaluator);
        }
        private static string ReplaceMatchEvaluator(Match m)
        {
            // m.Value contains the matched string including the braces.
            // This method is invoked once per matching portion of the input string.
            // We can then extract each of the named groups in order to access the
            // substrings of each matching portion as follows:
            var value0 = m.Groups["value0"].Value; // Contains first value, e.g. "Jwala Vora"
            var value1 = m.Groups["value1"].Value; // Contains second value, e.g. "3"
            var value2 = m.Groups["value2"].Value; // Contains third value, e.g. "13"
            // Here we return the value with which the matching portion is replaced.
            // This would be some function of the substrings.
            return "some function of value0, value1 and value2"
        }
    }
