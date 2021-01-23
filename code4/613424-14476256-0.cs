    public static class ListExtensions
    {
        /// <summary>
        /// Finds the indices of all objects matching the given predicate.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Indices of all objects matching the given predicate.</returns>
        public static IEnumerable<int> FindIndices<T>(this IList<T> list, Func<T, bool> predicate)
        {
            return list.Where(predicate).Select(list.IndexOf);
        }
    }
