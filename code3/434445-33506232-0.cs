    public static class StringHelpers
    {
        /// <summary>
        /// Convert string to boolean, in a forgiving way.
        /// </summary>
        /// <param name="stringVal">String that should either be "True", "False", "Yes", "No", "T", "F", "Y", "N", "1", "0"</param>
        /// <returns>If the trimmed string is any of the legal values that can be construed as "true", it returns true; False otherwise;</returns>
        public static bool ToBoolFuzzy(this string stringVal)
        {
            string normalizedString = (stringVal?.Trim() ?? "false").ToLowerInvariant();
            bool result = (normalizedString.StartsWith("y") 
                || normalizedString.StartsWith("t")
                || normalizedString.StartsWith("1"));
            return result;
        }
    }
