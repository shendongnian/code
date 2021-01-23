    public class TupleEqualityComparer<T1, T2> : IEqualityComparer<Tuple<T1, T2>>
    {
        private IEqualityComparer<T1> comparer1;
        private IEqualityComparer<T2> comparer2;
        public TupleEqualityComparer(IEqualityComparer<T1> comparer1, IEqualityComparer<T2> comparer2)
        {
            this.comparer1 = comparer1 ?? EqualityComparer<T1>.Default;
            this.comparer2 = comparer2 ?? EqualityComparer<T2>.Default;
        }
        public bool Equals(Tuple<T1, T2> lhs, Tuple<T1, T2> rhs)
        {
            return comparer1.Equals(lhs.Item1, rhs.Item1) && comparer2.Equals(lhs.Item2, rhs.Item2);
        }
        public int GetHashCode(Tuple<T1, T2> tuple)
        {
            return comparer1.GetHashCode(tuple.Item1) ^ comparer2.GetHashCode(tuple.Item2);
        }
    }
    public class Dictionary<TKey1, TKey2, TValue> : Dictionary<Tuple<TKey1, TKey2>, TValue>()
    {
        public Dictionary() : base() { }
        public Dictionary(IEqualityComparer<TKey1> comparer1, IEqualityComparer<TKey2> comparer2) : base(new TupleEqualityComparer<TKey1, Tkey2>(comparer1, comparer2) { }
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { return base[Tuple.Create(key1, key2)]; }
        }
        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            base.Add(Tuple.Create(key1, key2), value);
        }
        public bool ContainsKey(TKey1 key1, TKey2 key2)
        {
            return base.ContainsKey(Tuple.Create(key1, key2));
        }
        public bool TryGetValue(TKey1 key1, TKey2 key2, out TValue value)
        {
            return base.TryGetValue(Tuple.Create(key1, key2), out value);
        }
    }
