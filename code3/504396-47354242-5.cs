    public static class CollectionExtensions
    {
        /// <summary>
        /// Splits collection into number of collections of nearly equal size.
        /// </summary>
        public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> src, int slicesCount)
        {
            if (slicesCount <= 0) throw new ArgumentOutOfRangeException(nameof(slicesCount));
    
            List<T> source = src.ToList();
            var sourceIndex = 0;
            for (var targetIndex = 0; targetIndex < slicesCount; targetIndex++)
            {
                var list = new List<T>();
                int itemsLeft = source.Count - targetIndex;
                while (slicesCount * list.Count < itemsLeft)
                {
                    list.Add(source[sourceIndex++]);
                }
    
                yield return list;
            }
        }
    
        /// <summary>
        /// Takes collection of collections, projects those in parallel and merges results.
        /// </summary>
        public static async Task<IEnumerable<TResult>> SelectManyAsync<T, TResult>(
            this IEnumerable<IEnumerable<T>> source,
            Func<T, Task<TResult>> func)
        {
            List<TResult>[] slices = await source
                .Select(async slice => await slice.SelectListAsync(func).ConfigureAwait(false))
                .WhenAll()
                .ConfigureAwait(false);
            return slices.SelectMany(s => s);
        }
    
        /// <summary>Runs selector and awaits results.</summary>
        public static async Task<List<TResult>> SelectListAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            List<TResult> result = new List<TResult>();
            foreach (TSource source1 in source)
            {
                TResult result1 = await selector(source1).ConfigureAwait(false);
                result.Add(result1);
            }
            return result;
        }
    
        /// <summary>Wraps tasks with Task.WhenAll.</summary>
        public static Task<TResult[]> WhenAll<TResult>(this IEnumerable<Task<TResult>> source)
        {
            return Task.WhenAll<TResult>(source);
        }
    }
