        public static string ToAbbreviation(this TimeZone currentTimeZone)
        {
            string timeZoneString = currentTimeZone.StandardName;
            string result = string.Concat(System.Text.RegularExpressions.Regex
               .Matches(timeZoneString, "[A-Z]")
               .OfType<System.Text.RegularExpressions.Match>()
               .Select(match => match.Value));
            return result;
        }
