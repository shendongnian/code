    class Permutator
    {
        private static IEnumerable<IEnumerable<int>> CreateIndices(int length)
        {
            var factorial = Enumerable.Range(2, length - 1)
                .Aggregate((a, b) => a * b);
            return (from p in Enumerable.Range(0, factorial)
                    // creating module values from 2 up to length
                    // e.g. length = 3: mods = [ p%2, p%3 ]
                    // e.g. length = 4: mods = [ p%2, p%3, p%4 ]
                    let mods = Enumerable.Range(2, length - 1)
                        .Select(m => p % m).ToArray()
                    select (
                        // creating indices for each permutation
                        mods.Aggregate(
                            new[] { 0 },
                            (s, i) =>
                                s.Take(i)
                                .Concat(new[] { s.Length })
                                .Concat(s.Skip(i)).ToArray())
                        ));
        }
        public static IEnumerable<IEnumerable<T>> Get<T>(IEnumerable<T> items)
        {
            var array = items.ToArray();
            return from indices in CreateIndices(array.Length)
                    select (from i in indices select array[i]);
        }
    }
