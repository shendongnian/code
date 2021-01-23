        public static bool MyIsIncreasingMonotonicallyBy<T, TResult>(
                this IEnumerable<T> list, Func<T, TResult> selector)
            where TResult : IComparable<TResult>
        {
            var enumerable = list as IList<T> ?? list.ToList();
            return enumerable.Zip(
                       enumerable.Skip(1),
                       (a, b) => selector(a).CompareTo(selector(b)) <= 0
                   ).All(b => b);
        }
