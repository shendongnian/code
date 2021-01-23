    public static class Extensionmethods
    {
        /// <summary>
        /// Checks if both IEnumerables contain the same values regardless of their sequence
        /// </summary>
        /// <typeparam name="T">Type of Elements</typeparam>
        /// <param name="result">IEnumerable to compare to</param>
        /// <param name="compare">IEnumerable to compare to</param>
        /// <returns>Returns false if both IEnumerables contain the same values</returns>
        public static bool Differs<T>(this IEnumerable<T> result, IEnumerable<T> compare)
        {
            if (result == null && compare == null)
                return false;
            if (result != null && compare == null)
                return true;
            if (result == null && compare != null)
                return true;
            return result.Count() != compare.Count()
                || compare.Where(c => c == null).Count() != result.Where(r => r == null).Count()
                || compare.Where(c => c != null).Distinct().Any(item => result.Where(r => item.Equals(r)).Count() != compare.Where(r => item.Equals(r)).Count());
        }
        /// <summary>
        /// Checks if both IEnumerables contain the same values (corresponding to <paramref name="comparer"/> regardless of their sequence
        /// </summary>
        /// <typeparam name="T">Type of Elements</typeparam>
        /// <param name="result">IEnumerable to compare to</param>
        /// <param name="compare">IEnumerable to compare to</param>
        /// <param name="comparer">IEqualityComparer to use</param>
        /// <returns>Returns false if both IEnumerables contain the same values</returns>
        public static bool Differs<T>(this IEnumerable<T> result, IEnumerable<T> compare, IEqualityComparer<T> comparer)
        {
            if (result == null && compare == null)
                return false;
            if (result != null && compare == null)
                return true;
            if (result == null && compare != null)
                return true;
            return result.Count() != compare.Count()
                || compare.Where(c => c == null).Count() != result.Where(r => r == null).Count()
                || compare.Where(c => c != null).Distinct().Any(item => result.Where(r => comparer.Equals(item, r)).Count() != compare.Where(r => comparer.Equals(item, r)).Count());
        }
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> compareFunction, Func<T, int> hashFunction = null)
        {
            var ecomparer = new DynamicEqualityComparer<T>(compareFunction, hashFunction);
            return source.Distinct(ecomparer);
        }
    }
    internal class DynamicEqualityComparer<T> : IEqualityComparer<T>
    {
        public DynamicEqualityComparer(Func<T, T, bool> equalFunction, Func<T, int> hashFunction = null)
        {
            this.equalFunc = equalFunction;
            this.hashFunc = hashFunction;
        }
        private Func<T, T, bool> equalFunc;
        public bool Equals(T x, T y)
        {
            if (x == null && y == null) return true;
            if (x == null) return false;
            if (y == null) return false;
            if (hashFunc != null)
            {
                if (hashFunc.Invoke(x) != hashFunc.Invoke(y)) return false;
            }
            return this.equalFunc.Invoke(x, y);
        }
        private Func<T, int> hashFunc;
        public int GetHashCode(T obj)
        {
            if (hashFunc != null) return hashFunc.Invoke(obj);
            return 0;
        }
    }
