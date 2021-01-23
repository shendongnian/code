            // Below is a breakdown of this regular expression:
            // First, one to ten digits followed by "d" or "D" to represent days.
            // Second, one to ten digits followed by "h" or "H" to represent hours.
            // Third, one to ten digits followed by "m" or "M" to represent minutes.
            // Each component can be separated by any number of spaces, or none.
            private static readonly Regex DurationRegex = new Regex(@"((?<Days>\d{1,10})d)?\s*((?<Hours>\d{1,10})h)?\s*((?<Minutes>\d{1,10})m)?", RegexOptions.IgnoreCase);
    
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
                    0);
            }
