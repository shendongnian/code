        public static string ToAbbreviation(this TimeZone theTimeZone)
        {
            string timeZoneString = theTimeZone.StandardName;
            string result = string.Concat(System.Text.RegularExpressions.Regex
               .Matches(timeZoneString, "[A-Z]")
               .OfType<System.Text.RegularExpressions.Match>()
               .Select(match => match.Value));
            return result;
        }
