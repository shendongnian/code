    /// <summary>
    /// A set of extension methods for <see cref="IEnumerable{T}"/>. 
    /// </summary>
    public static class EnumerableExtender
    {
        /// <summary>
        /// Splits an enumerable into chucks, by a maximum group size.
        /// </summary>
        /// <param name="source">The source to split</param>
        /// <param name="maxSize">The maximum number of items per group.</param>
        /// <typeparam name="T">The type of item to split</typeparam>
        /// <returns>A list of lists of the original items.</returns>
        public static IEnumerable<IEnumerable<T>> PartitionByMaxGroupSize<T>(this IEnumerable<T> source, int maxSize)
        {
            return new SplittingEnumerable<T>(source, maxSize);
        }
    }
