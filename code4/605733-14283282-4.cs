    public class MultiKeyDictionary2<T1, T2, T3>
    {
        private HashSet<Tuple<T1, T2, T3>> lookup = new HashSet<Tuple<T1, T2, T3>>();
        private HashSet<T1> firstKeys = new HashSet<T1>();
        private HashSet<T2> secondKeys = new HashSet<T2>();
        private HashSet<T3> thirdKeys = new HashSet<T3>();
    
        public void Add(Tuple<T1, T2, T3> values)
        {
            if (lookup.Any(multiKey => object.Equals(multiKey.Item1, values.Item1) ||
                object.Equals(multiKey.Item2, values.Item2) ||
                object.Equals(multiKey.Item3, values.Item3)))
            {
                //throw an exception or something
            }
            else
            {
                lookup.Add(values);
            }
        }
    
        public Tuple<T1, T2, T3> GetFirst(T1 key)
        {
            return lookup.FirstOrDefault(values => object.Equals(values.Item1, key));
        }
    
        public Tuple<T1, T2, T3> GetSecond(T2 key)
        {
            return lookup.FirstOrDefault(values => object.Equals(values.Item2, key));
        }
    
        public Tuple<T1, T2, T3> GetThird(T3 key)
        {
            return lookup.FirstOrDefault(values => object.Equals(values.Item3, key));
        }
    
        public void RemoveFirst(T1 key)
        {
            var values = GetFirst(key);
            if (values != null)
                lookup.Remove(values);
        }
    
        public void RemoveSecond(T2 key)
        {
            var values = GetSecond(key);
            if (values != null)
                lookup.Remove(values);
        }
    
        public void RemoveThird(T3 key)
        {
            var values = GetThird(key);
            if (values != null)
                lookup.Remove(values);
        }
    }
