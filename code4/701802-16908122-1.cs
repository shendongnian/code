    internal static class ParseRule
    {
        public static bool IsValid<TRule>(this string input, bool throwError = false) where TRule : IParseRule, new()
        {
            string errorMessage;
            IParseRule rule = new TRule();
            if (rule.Parse(input, out errorMessage))
            {
                return true;
            }
            else if (throwError)
            {
                throw new FormatException(errorMessage);
            }
            else
            {
                return false;
            }
        }
        public static void CheckArg<TRule>(this string input, string paramName) where TRule : IParseRule, new()
        {
            string errorMessage;
            IParseRule rule = new TRule();
            if (!rule.Parse(input, out errorMessage))
            {
                throw new ArgumentException(errorMessage, paramName);
            }
        }
        [Conditional("DEBUG")]
        public static void DebugAssert<TRule>(this string input) where TRule : IParseRule, new()
        {
            string errorMessage;
            IParseRule rule = new TRule();
            Debug.Assert(rule.Parse(input, out errorMessage), "Malformed input: " + errorMessage);
        }
    }
