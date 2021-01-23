        /// <summary>
        /// Returns the provided collection of strings without any empty strings.
        /// </summary>
        /// <param name="items">The collection to filter</param>
        /// <returns>The collection without any empty strings.</returns>
        public static IEnumerable<string> RemoveEmpty(this IEnumerable<string> items)
        {
            return items.Where(i => !String.IsNullOrEmpty(i));
        }
