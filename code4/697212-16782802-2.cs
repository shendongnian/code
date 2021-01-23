    static class Extensions
    {
        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        public static string Right(this string value, int length)
        {
    	    if(String.IsNullOrEmpty(value)) return string.Empty;
    	    if(value.Lenght <= length) return value;
    	    return value.Substring(value.Length - length);
        }
    }
