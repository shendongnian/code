    static class EnumerableExtensions
    {
        public static IEnumerable<T> FirstRepeatedTimes<T>(this IEnumerable<T> sequence, int threshold)
        {
            if (!sequence.Any())
                throw new ArgumentException("Sequence must contain elements", "sequence");
            if (threshold < 2)
                throw new ArgumentException("DuplicateCount must be greater than 1", "threshold");
    
            return FirstRepeatedTimesImpl(sequence, threshold);
        }
        
        static IEnumerable<T> FirstRepeatedTimesImpl<T>(this IEnumerable<T> sequence, int threshold)
        {
            var map = new Dictionary<T, int>();
            foreach(var e in sequence)
            {
                if (!map.ContainsKey(e))
                    map.Add(e, 0);
                if (map[e] + 1 == threshold)
                {
                    yield return e;
                    yield break;
                }
                map[e] = map[e] + 1;
            }
        }
    }
