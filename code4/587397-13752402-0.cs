    public DynamicArrayEnumerator<T> GetEnumerator()
    {
        return new DynamicArrayEnumerator<T>(this);
    }
    IEnumerator<T> IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
