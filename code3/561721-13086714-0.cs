    class Program {
        static IEnumerable<IEnumerable<T>> CombineSets<T>(
            IEnumerable<IEnumerable<T>> sets,
            IEqualityComparer<T> eq
        ) {
            var result_sets = new List<HashSet<T>>();                   // 1
            foreach (var set in sets) {
                var result_set = new HashSet<T>(eq);                    // 3
                foreach (var element in set) {
                    result_set.Add(element);                            // 4
                    for (int i = 0; i < result_sets.Count; ) {
                        if (result_sets[i].Contains(element)) {         // 2
                            result_set.UnionWith(result_sets[i]);       // 4
                            result_sets.RemoveAt(i);                    // 2
                        }
                        else
                            ++i;
                    }
                }
                result_sets.Add(result_set);                            // 3
            }
            return result_sets;
        }
        static IEnumerable<IEnumerable<T>> CombineSets<T>(
            IEnumerable<IEnumerable<T>> src
        ) {
            return CombineSets(src, EqualityComparer<T>.Default);
        }
        static void Main(string[] args) {
            var sets = new[] {
                new[] { 1, 2 }, 
                new[] { 3, 4 }, 
                new[] { 2, 4 }, 
                new[] { 9, 10 }, 
                new[] { 9, 12, 13, 14 }
            };
            foreach (var result in CombineSets(sets))
                Console.WriteLine(
                    "{{{0}}}",
                    string.Join(",", result.OrderBy(x => x))
                );
        }
    }
