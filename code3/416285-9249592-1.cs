    public static class StringExtensions
    {
        public static string ToPascalCase(this string s)
        {
            if (string.IsNullOrEmpty(s) || !char.IsLower(s[0]))
                return s;
            string str = char.ToUpper(s[0], CultureInfo.InvariantCulture).ToString((IFormatProvider)CultureInfo.InvariantCulture);
            if (s.Length > 1)
                str = str + s.Substring(1);
            return str;
        }
    }
