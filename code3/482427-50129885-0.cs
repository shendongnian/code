        public static string ExtractNumbers(this string source)
        {
            if (String.IsNullOrWhiteSpace(source))
                return string.Empty;
            var number = Regex.Match(source, @"\d+");
            if (number != null)
                return number.Value;
            else
                return string.Empty;
        }
