    public static class StringExtensions
    {
        /// <summary>
        /// Formats a string using the string.Format(string, params object[])
        /// </summary>
        /// <param name="helper">The string with the format.</param>
        /// <param name="args">The value args.</param>
        /// <returns>The formatted string with the args mended in.</returns>
        public static string Mend(this string helper, params object[] args) => string.Format(helper, args);
    }
