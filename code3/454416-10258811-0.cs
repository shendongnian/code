        public static IEnumerable<Severity> SeverityOrHigher(Severity severity)
        {
            var value = (int) severity;
            return Enum.GetValues(typeof (Severity))
                .Cast<int>()
                .Where(i => i >= value)
                .Select(i => (Severity) i);
        }
        public enum Severity
        {
            All = 0,
            Trace = 1,
            Debug = 2,
            Information = 3,
            Warning = 4,
            Error = 5,
            Fatal = 6
        }
