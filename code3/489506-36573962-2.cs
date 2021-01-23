    /// <summary>
    /// Extension class for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Get the nummer of lines in the string.
        /// </summary>
        /// <returns>Nummer of lines</returns>
        public static int LineCount(this string str)
        {
            return str.Split('\n').Length;
        }
    }
