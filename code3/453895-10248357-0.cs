    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)dict.Keys.GetEnumerator();
    }
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)dict.Keys.GetEnumerator();
    }
