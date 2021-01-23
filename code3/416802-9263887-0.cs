    public static class RegexExtensions {
        public static bool GetMatch(this Regex regex, string input, out string matched) {
            Match match = regex.Match(input);
            if (match.Success) {
                matched = match.Value;
                return true;
            }
            matched = null;
            return false;
        }
    }
