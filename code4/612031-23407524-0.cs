        /// <summary>
        /// Converts the value of the specified string to a truncated string representation
        /// </summary>
        /// <param name="source">The specified string</param>
        /// <param name="length">Integer specifying the maximum number of characters to retain from the specified string.</param>
        /// <param name="appendEllipsis">Determines whether or not to append an ellipsis to the truncated result.  If the specified string is shorter than the length parameter the ellipsis will not be appended in any event.</param>
        /// <returns>A truncated string representation of the specified string.</returns>
        public static String Truncate(this String source, int length, bool appendEllipsis = false)
        {
            if (source.Length <= length)
                return source;
            return (appendEllipsis)
                ? String.Concat(source.Substring(0, length), "...")
                : source.Substring(0, length);
        }
