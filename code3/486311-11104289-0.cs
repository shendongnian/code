        /// <summary>
        /// Determines whether the supplied string begins with "ta".
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>True if the supplied string starts with "ta"; false, otherwise.</returns>
        /// <remarks>The comparison is case-insensitive.</remarks>
        private static bool StartsWithTa(string value)
        {
            const string prefix = "ta";
            if (value == null)
                return false;
            return value.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase);
        }
