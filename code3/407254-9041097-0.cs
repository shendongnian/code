        #region Fields
        /// <summary>Current implementation of the hash is a dictionary</summary>
        private readonly Dictionary<string, T> _HashItems = new Dictionary<string, T>();
        #endregion
        #region Properties
        /// <summary>How many items are currently in the hash</summary>
        public virtual int Count { get { return _HashItems.Count; } }
        /// <summary>Indexer provides hashed (by string) lookup</summary>
        public virtual T this[string index]
        {
            get { return index != null && _HashItems.ContainsKey(index) ? _HashItems[index] : default(T); }
        }
        #endregion
        #region Constructors
        /// <summary>Default constructor initializes hash with no members</summary>
        public BindableHash() : this(null) { }
        /// <summary>Injected constructor seeds the list using the tuples passsed in</summary>
        public BindableHash(params Tuple<string, T>[] initialTuples)
        {
            foreach (Tuple<string, T> tuple in initialTuples ?? new Tuple<string, T>[] { })
            {
                Add(tuple);
            }
        }
        #endregion
        #region Methods
        /// <summary>Add a key-value pair to the hash</summary>
        public virtual void Add(string key, T value)
        {
            Add(new Tuple<string, T>(key, value));
        }
        /// <summary>Removes all items from the hash</summary>
        public virtual void Clear()
        {
            _HashItems.Clear();
        }
        
        /// <summary>Remove a particular value from the hash</summary>
        public bool Remove(string key)
        {
            return key != null && _HashItems.Remove(key);
        }
        #endregion
        #region Helpers
        /// <summary>Abstraction for adding a key value pair</summary>
        protected void Add(Tuple<string, T> tuple)
        {
            if (tuple != null && tuple.Item1 != null)
            {
                _HashItems[tuple.Item1] = tuple.Item2;
            }
        }
        #endregion
        #region IEnumerable<T> Members
        /// <summary>Define enumerator retrieval to allow enumeration over values</summary>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T value in _HashItems.Values)
            {
                yield return value;
            }
        }
        #endregion
        #region IEnumerable Members
        /// <summary>Impelementation for clients who cast this as non-generic IEnumerable</summary>
        /// <remarks>If you're not familiar with the black magic going on here, IEnmerable generic interface inherits from
        /// IEnumerable non-generic (legacy).  Both interfaces define GetEnumerator, and one returns a generic IEnumerator and the other
        /// a non-generic IEnumerator.  This one is the non-generic, and we want to 'hide' it for type safety purposes.  When you 
        /// do an explicit interface implementation, you create some kind of visibility purgatory.  This method is not private/protected
        /// because the interface is public, but it is also not a public method of this class.  The only way you can get to this guy is by casting
        /// BindableHash as IEnumerable (non-generic) and invoking the method that way.  Since that is possible to do, we have to implement the method,
        /// which we do by just invoking our generic one.  This is legal because of the fact that IEnumerator generic inherits from non-generic IEnumerator.
        /// Clear as mud?  You can ask me for a more detailed explanation, if you like --ebd</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
