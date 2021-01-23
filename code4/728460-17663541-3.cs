    public static class StringIndexExtensions
    {
        public static bool CaseSensitiveContainsAny(this char[] matchChars, string textToCheck)
        {
            return matchChars.Any(c => textToCheck.IndexOf(
                c.ToString(CultureInfo.InvariantCulture),
                StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
