    class Permutator
    {
        public static IEnumerable<IEnumerable<T>> Get<T>(IEnumerable<T> items)
        {
            return
                from p in Enumerable.Range(0,
                    Enumerable.Range(2, items.Count() - 1)
                        .Aggregate((a, b) => a * b))
                let mods = Enumerable.Range(2, items.Count() - 1)
                    .Select(m => p % m).ToArray()
                select mods.Aggregate(
                    items.Take(1).ToArray(),
                    (s, i) =>
                        s.Take(i)
                        .Concat(items.Skip(s.Length).Take(1))
                        .Concat(s.Skip(i)).ToArray());
        }
    }
