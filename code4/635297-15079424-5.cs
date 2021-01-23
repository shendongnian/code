        // Below is a breakdown of this regular expression:
        // First, one to ten digits followed by "d", "dys", "day", or "days".
        // Second, one to ten digits followed by "h", "hrs", "hour", or "hours".
        // Third, one to ten digits followed by "m", "min", "minute", or "minutes".
        // Fourth, one to ten digits followed by "s", "sec", "second", or "seconds".
        // Fifth, one to ten digits followed by "ms", "msec", "millisec", "millisecond", or "milliseconds".
        // Each component must be separated by at least one space.
        // This expression is case-insensitive.
        private static readonly Regex DurationRegex = new Regex(@"
            ((?<Days>\d{1,10})(d|dys|day|days)($|\s+))?
            ((?<Hours>\d{1,10})(h|hrs|hour|hours)($|\s+))?
            ((?<Minutes>\d{1,10})(m|min|minute|minutes)($|\s+))?
            ((?<Seconds>\d{1,10})(s|sec|second|seconds)($|\s+))?
            ((?<Milliseconds>\d{1,10})(ms|msec|millisec|millisecond|milliseconds)($|\s+))?", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
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
