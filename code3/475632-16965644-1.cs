        /// <summary>
        /// Gets initials from the supplied names string.
        /// </summary>
        /// <param name="names">Names separated by whitespace</param>
        /// <param name="separator">Separator between initials (e.g. "", "." or ". ") </param>
        /// <returns>Upper case initials (with separators in between)</returns>
        public static string GetInitials(string names, string separator)
        {
            // Extract the first character out of each block of non-whitespace
            Regex extractInitials = new Regex(@"\s*([^\s])[^\s]*\s*");
            return extractInitials.Replace(names, "$1" + separator).ToUpper();
        }
