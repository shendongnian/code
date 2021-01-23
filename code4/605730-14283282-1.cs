    public class MultiKeyDictionary<T1, T2, T3>
    {
        private Dictionary<T1, Tuple<T1, T2, T3>> firstLookup = new Dictionary<T1, Tuple<T1, T2, T3>>();
        private Dictionary<T2, Tuple<T1, T2, T3>> secondLookup = new Dictionary<T2, Tuple<T1, T2, T3>>();
        private Dictionary<T3, Tuple<T1, T2, T3>> thirdLookup = new Dictionary<T3, Tuple<T1, T2, T3>>();
    
        public void Add(Tuple<T1, T2, T3> values)
        {
            if (!firstLookup.ContainsKey(values.Item1) &&
                !secondLookup.ContainsKey(values.Item2) &&
                !thirdLookup.ContainsKey(values.Item3))
            {
                firstLookup.Add(values.Item1, values);
                secondLookup.Add(values.Item2, values);
                thirdLookup.Add(values.Item3, values);
            }
            else
            {
                //throw an exeption or something.
            }
        }
    
        public Tuple<T1, T2, T3> GetFirst(T1 key)
        {
            return firstLookup[key];
        }
    
        public Tuple<T1, T2, T3> GetFirst(T2 key)
        {
            return secondLookup[key];
        }
    
        public Tuple<T1, T2, T3> GetFirst(T3 key)
        {
            return thirdLookup[key];
        }
    
        public void RemoveFirst(T1 key)
        {
            var values = GetFirst(key);
    
            firstLookup.Remove(values.Item1);
            secondLookup.Remove(values.Item2);
            thirdLookup.Remove(values.Item3);
        }
    }
