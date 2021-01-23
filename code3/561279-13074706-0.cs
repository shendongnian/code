        public static IEnumerable<TSource> DistinctBy<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult> keySelector)
        {
            Dictionary<TResult, TSource> seenItems = new Dictionary<TResult, TSource>();
            foreach (var item in enumerable)
            {
                var key = keySelector(item);
                if (!seenItems.ContainsKey(key))
                {
                    seenItems.Add(key, item);
                    yield return item;
                }
            }
        }
