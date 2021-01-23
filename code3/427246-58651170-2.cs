cs
        public static Dictionary<TK, TV> ValueDiff<TK, TV>(this Dictionary<TK, TV> dictionary,
            Dictionary<TK, TV> otherDictionary)
        {
            IEnumerable<(TK key, TV otherValue)> DiffKey(KeyValuePair<TK, TV> kv)
            {
                var otherValue = otherDictionary[kv.Key];
                if (!Equals(kv.Value, otherValue))
                {
                    yield return (kv.Key, otherValue);
                }
            }
            return dictionary.SelectMany(DiffKey)
                .ToDictionary(t => t.key, t => t.otherValue, dictionary.Comparer);
        }
I am not sure that `SelectMany`is always the fastest solution, but it is one way to only select the relevant items and generate the resulting entries in the same step. Sadly C# does not support `yield return` in lambdas and while I could have constructed single or no item collections, I choose to use an inner function.
Oh and as you say that the keys are the same, it may be possible to order them. Then you could use `Zip`
cs
        public static Dictionary<TK, TV> ValueDiff<TK, TV>(this Dictionary<TK, TV> dictionary,
            Dictionary<TK, TV> otherDictionary)
        {
            return dictionary.OrderBy(kv => kv.Key)
                .Zip(otherDictionary.OrderBy(kv => kv.Key))
                .Where(p => !Equals(p.First.Value, p.Second.Value))
                .ToDictionary(p => p.Second.Key, p => p.Second.Value, dictionary.Comparer);
        }
Personally I would tend not to use Linq, but a simple `foreach` like carlosfigueira and vanfosson:
cs
        public static Dictionary<TK, TV> ValueDiff2<TK, TV>(this Dictionary<TK, TV> dictionary,
            Dictionary<TK, TV> otherDictionary)
        {
            var result = new Dictionary<TK, TV>(dictionary.Count, dictionary.Comparer);
            foreach (var (key, value) in dictionary)
            {
                var otherValue = otherDictionary[key];
                if (!Equals(value, otherValue))
                {
                    result.Add(key, otherValue);
                }
            }
            return result;
        }
