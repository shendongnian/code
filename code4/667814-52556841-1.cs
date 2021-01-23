        /// <summary>
        /// combines 2 strings by inserting the replacement string into the original 
        /// string starting at the start position and will remove up to CharsToRemove 
        /// from the original string before appending the remainder.
        /// </summary>
        /// <param name="original">original string to modify</param>
        /// <param name="start">starting point for insertion, 0-based</param>
        /// <param name="charstoremove">number of characters from original string to remove</param>
        /// <param name="replacement">string to insert</param>
        /// <returns>a new string as follows:
        /// {original,0,start}{replacement}{original,start+charstoremove,end}
        /// </returns>
        /// <example>
        /// "ABC".Split(1,1,"123") == "A123C"
        /// </example>
        public static string Splice(this string original, int start, int charstoremove,
                                    string replacement)
        {
            // protect from null reference exceptions
            if (original == null)
                original = "";
            if (replacement == null)
                replacement = "";
            var sb = new StringBuilder();
            if (start < 0)
                start = 0;
            // start is too big, concatenate strings
            if (start >= original.Length)
            {
                sb.Append(original);
                sb.Append(replacement);
                return sb.ToString();
            }
            // take first piece + replacement
            sb.Append(original.Substring(0, start));
            sb.Append(replacement);
            // if new length is bigger then old length, return what we have
            if (start+charstoremove >= original.Length)
                return sb.ToString();
            // otherwise append remainder
            sb.Append(original.Substring(start + charstoremove));
            return sb.ToString();
        }
