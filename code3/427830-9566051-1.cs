    public static class FrameworkExtensions
    {
        /// <summary>
        /// null tolerant access to a Collection
        /// 
        /// usage:
        /// foreach (int i in returnArray.AsNotNull())
        /// {
        ///     // do some more stuff
        /// }
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> original)
        {
            return original ?? new T[0];
        }
    }
