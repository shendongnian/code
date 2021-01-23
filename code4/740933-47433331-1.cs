    public static class EnumerableExtensions
    {
        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate,
        /// and returns the zero-based index of the first occurrence within the entire <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="predicate"/>, if found; otherwise it'll throw.
        /// </returns>
        public static int FindIndex<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            var idx = list.Select((value, index) => new {value, index}).Where(x => predicate(x.value)).Select(x => x.index).First();
            return idx;
        }
    }
