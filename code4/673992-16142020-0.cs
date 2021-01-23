    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("jon skeet".isAnagram("jokes net"));
            Console.Read();
        }
    }
    public static class Extensions
    {
        public static bool isAnagram(this string s, string t)
        {
            return s.Decompose().DictionaryEqual(t.Decompose());
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
        public static Dictionary<char, int> Decompose(this string s)
        {
            var d = new Dictionary<char, int>();
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
