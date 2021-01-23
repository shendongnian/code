    // Public method returning a mutable struct for efficiency
    public List<T>.Enumerator GetEnumerator()
    {
        return _list.GetEnumerator();
    }
    // Explicit implementation of non-generic interface
    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        return GetEnumerator();
    }
    // Explicit implementation of non-generic interface
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
