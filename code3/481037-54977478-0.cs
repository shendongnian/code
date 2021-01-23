    public class Map<T1, T2> : IEnumerable<KeyValuePair<T1, T2>>
    {
        private readonly Dictionary<T1, T2> _forward;
        private readonly Dictionary<T2, T1> _reverse;
        /// <summary>
        /// Constructor that uses the default comparers for the keys in each direction.
        /// </summary>
        public Map()
            : this(null, null)
        {
        }
        /// <summary>
        /// Constructor that defines the comparers to use when comparing keys in each direction.
        /// </summary>
        /// <param name="t1Comparer">Comparer for the keys of type T1.</param>
        /// <param name="t2Comparer">Comparer for the keys of type T2.</param>
        /// <remarks>Pass null to use the default comparer.</remarks>
        public Map(IEqualityComparer<T1> t1Comparer, IEqualityComparer<T2> t2Comparer)
        {
            _forward = new Dictionary<T1, T2>(t1Comparer);
            _reverse = new Dictionary<T2, T1>(t2Comparer);
            Forward = new Indexer<T1, T2>(_forward);
            Reverse = new Indexer<T2, T1>(_reverse);
        }
        // Remainder is the same as Xavier John's answer:
        // https://stackoverflow.com/a/41907561/216440
        ...
    }
