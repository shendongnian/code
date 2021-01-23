    public DynamicArrayEnumerator<T> GetEnumerator()
    {
        return new DynamicArrayEnumerator<T>(this);
    }
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
