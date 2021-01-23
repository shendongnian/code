    using System;
    using System.Text.RegularExpressions;
    
    namespace RegexCaptureGroups
    {
        class Program
        {
            // Below is a breakdown of this regular expression:
            // First, one or more digits followed by "d" or "D" to represent days.
            // Second, one or more digits followed by "h" or "H" to represent hours.
            // Third, one or more digits followed by "m" or "M" to represent minutes.
            // Each component can be separated by any number of spaces, or none.
            private static readonly Regex DurationRegex = new Regex(@"((?<Days>\d+)d)?\s*((?<Hours>\d+)h)?\s*((?<Minutes>\d+)m)?", RegexOptions.IgnoreCase);
    
            public static TimeSpan ParseDuration(string input)
            {
                var match = DurationRegex.Match(input);
    
                var days = match.Groups["Days"].Value;
                var hours = match.Groups["Hours"].Value;
                var minutes = match.Groups["Minutes"].Value;
    
                int daysAsInt32, hoursAsInt32, minutesAsInt32;
    
                if (!int.TryParse(days, out daysAsInt32))
                    daysAsInt32 = 0;
    
                if (!int.TryParse(hours, out hoursAsInt32))
                    hoursAsInt32 = 0;
    
                if (!int.TryParse(minutes, out minutesAsInt32))
                    minutesAsInt32 = 0;
    
                return new TimeSpan(daysAsInt32, hoursAsInt32, minutesAsInt32, 0);
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine(ParseDuration("30d"));
                Console.WriteLine(ParseDuration("12h"));
                Console.WriteLine(ParseDuration("20m"));
                Console.WriteLine(ParseDuration("1d 12h"));
                Console.WriteLine(ParseDuration("5d 30m"));
                Console.WriteLine(ParseDuration("1d 12h 20m"));
    
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
