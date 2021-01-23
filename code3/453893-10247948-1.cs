    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)dict.Keys).GetEnumerator();
    }
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return ((IEnumerator<T>)dict.Keys).GetEnumerator();
    }
