    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)dict.Keys).GetEnumerator();
    }
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return ((IEnumerable<T>)dict.Keys).GetEnumerator();
    }
