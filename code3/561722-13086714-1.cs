    class Program {
        static IEnumerable<IEnumerable<T>> CombineSets<T>(
            IEnumerable<IEnumerable<T>> sets,
            IEqualityComparer<T> eq
        ) {
            var result_sets = new LinkedList<HashSet<T>>();         // 1
            foreach (var set in sets) {
                var result_set = new HashSet<T>(eq);                // 3
                foreach (var element in set) {
                    result_set.Add(element);                        // 4
                    var node = result_sets.First;
                    while (node != null) {
                        var next = node.Next;
                        if (node.Value.Contains(element)) {         // 2
                            result_set.UnionWith(node.Value);       // 4
                            result_sets.Remove(node);               // 2
                        }
                        node = next;
                    }
                }
                result_sets.AddLast(result_set);                    // 3
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
