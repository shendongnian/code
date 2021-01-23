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
        public static bool IsPermutationOf<TKey>(this  IEnumerable<TKey> s, IEnumerable<TKey> t)
        {
            return s.IsPermutationOf(t, EqualityComparer<TKey>.Default);
        }
        public static bool IsPermutationOf<TKey>(this IEnumerable<TKey> s, IEnumerable<TKey> t, EqualityComparer<TKey> comparer)
        {
            return s.Decompose(comparer).DictionaryEqual(t.Decompose(comparer));
        }
        public static bool DictionaryEqual<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            if (first == second) return true;
            if ((first == null) || (second == null)) return false;
            if (first.Count != second.Count) return false;
            var comparer = EqualityComparer<TValue>.Default;
            foreach (KeyValuePair<TKey, TValue> kvp in first)
            {
                TValue secondValue;
                if (!second.TryGetValue(kvp.Key, out secondValue)) return false;
                if (!comparer.Equals(kvp.Value, secondValue)) return false;
            }
            return true;
        }
        public static Dictionary<TKey, int> Decompose<TKey>(this IEnumerable<TKey> s, EqualityComparer<TKey> comparer)
        {
            var d = new Dictionary<TKey, int>(comparer);
            foreach (var c in s)
            {
                int count;
                if (d.TryGetValue(c, out count))
                {
                    d[c] = count + 1;
                }
                else
                {
                    d.Add(c, 1);
                }
            }
            return d;
        }
    }
