        // Below is a breakdown of this regular expression:
        // First, one to ten digits followed by "d", "dy", "dys", "day", or "days".
        // Second, one to ten digits followed by "h", "hr", "hrs", "hour", or "hours".
        // Third, one to ten digits followed by "m", "min", "minute", or "minutes".
        // Fourth, one to ten digits followed by "s", "sec", "second", or "seconds".
        // Fifth, one to ten digits followed by "ms", "msec", "millisec", "millisecond", or "milliseconds".
        // Each component may be separated by any number of spaces, or none.
        // The expression is case-insensitive.
        private static readonly Regex DurationRegex = new Regex(@"
            ((?<Days>\d{1,10})(d|dy|dys|day|days)(\b|(?=[^a-z])))?\s*
            ((?<Hours>\d{1,10})(h|hr|hrs|hour|hours)(\b|(?=[^a-z])))?\s*
            ((?<Minutes>\d{1,10})(m|min|minute|minutes)(\b|(?=[^a-z])))?\s*
            ((?<Seconds>\d{1,10})(s|sec|second|seconds)(\b|(?=[^a-z])))?\s*
            ((?<Milliseconds>\d{1,10})(ms|msec|millisec|millisecond|milliseconds)(\b|(?=[^a-z])))?",
            RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        private static int ParseInt32ZeroIfNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input) ? 0 : int.Parse(input);
        }
        public static TimeSpan ParseDuration(string input)
        {
            var match = DurationRegex.Match(input);
            return new TimeSpan(
                ParseInt32ZeroIfNullOrEmpty(match.Groups["Days"].Value),
                ParseInt32ZeroIfNullOrEmpty(match.Groups["Hours"].Value),
                ParseInt32ZeroIfNullOrEmpty(match.Groups["Minutes"].Value),
                ParseInt32ZeroIfNullOrEmpty(match.Groups["Seconds"].Value),
                ParseInt32ZeroIfNullOrEmpty(match.Groups["Milliseconds"].Value));
        }
