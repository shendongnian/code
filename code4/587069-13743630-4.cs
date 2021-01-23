    class IntIntDict<T> : Dictionary<Tuple<int, int>, T>
    {
        public T this[int index1, int index2]
        { get { return this[new Tuple(index1, index2)]; } }
        public bool ContainsKey (int index1, int index2)
        {
            return ContainsKey(new Tuple(index1, index2));
        }
        public void Add (int index1, int index2, T value)
        {
             Add(new Tuple(index1, index2), value);
        }
        // ...
    }
