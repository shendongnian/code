    using System.Text.RegularExpressions ;
    public static class StringExtensions
    {
        /// <summary>
        /// Get the nummer of lines in the string.
        /// </summary>
        /// <returns>Nummer of lines</returns>
        public static int LineCount(this string str)
        {
            return Regex.Matches( str , System.Environment.NewLine).Count ;
        }
    }
