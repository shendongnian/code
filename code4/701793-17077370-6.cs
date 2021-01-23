    class Permutator
    {
        private static IEnumerable<IEnumerable<int>> CreateIndices(int length)
        {
            return (from p in Enumerable.Range(0, length)
                    select (
                        from s in Permutator.CreateIndices(length - 1)
                                  .DefaultIfEmpty(Enumerable.Empty<int>())
                        select s.Take(p)
                               .Concat(new[] { length - 1 })
                               .Concat(s.Skip(p))
                        ))
                        .SelectMany(i => i);
        }
        public static IEnumerable<IEnumerable<T>> Get<T>(IEnumerable<T> items)
        {
            var array = items.ToArray();
            return from indices in CreateIndices(array.Length)
                    select (from i in indices select array[i]);
        }
    }
