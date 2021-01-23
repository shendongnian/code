        public static bool IsValidDecimalNumber(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false; //blank/null strings aren't valid decimal numbers
            return !s.Any(c => !(char.IsDigit(c) || c == '.')) && !(s.Count(c => c == '.') > 1);
        }
