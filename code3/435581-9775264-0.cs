        /// <summary>
        /// Conerts source to 2D array.
        /// </summary>
        /// <typeparam name="T">
        /// The type of item that must exist in the source.
        /// </typeparam>
        /// <param name="source">
        /// The source to convert.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if source is null.
        /// </exception>
        /// <returns>
        /// The 2D array of source items.
        /// </returns>
        public static T[,] To2DArray<T>(this IList<IList<T>> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
    
            int max = source.Select(l => l).Max(l => l.Count());
    
            var result = new T[source.Count, max];
    
            for (int i = 0; i < source.Count; i++)
            {
                for (int j = 0; j < source[i].Count(); j++)
                {
                    result[i, j] = source[i][j];
                }
            }
    
            return result;
        }
