    MyRigCollectionBase(IEnumerable<T> enumerable)
        : this (enumerable.ToList())
    {
        // Delegates to constructor below
    }
    MyRigCollectionBase(IList<T> list)
        : base (list)
    {
        // Delegates to constructor of Collection<T>.
    }
