    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("jon skeet".PermutationOf("jokes net"));
            Console.WriteLine(new[] { 5, 2, 3, 4, 5 }.PermutationOf(new[] { 5, 4, 5, 2, 3 }));
            Console.Read();
        }
    }
    public static class Extensions
    {
        public static bool IsPermutationOf<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
        {
            return source1.IsPermutationOf(source2, EqualityComparer<T>.Default);
        }
        public static bool IsPermutationOf<T>(this IEnumerable<T> source1, IEnumerable<T> source2, EqualityComparer<T> comparer)
        {
            return source1.Decompose(comparer).DictionaryEqual(source2.Decompose(comparer));
        }
        public static Dictionary<T, int> Decompose<T>(this IEnumerable<T> source, EqualityComparer<T> comparer)
        {
            return source.GroupBy(t => t, comparer).ToDictionary(t => t.Key, t => t.Count(), comparer);
        }
        public static bool DictionaryEqual<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            return first.Count == second.Count && !first.Except(second).Any();
        }
    }
