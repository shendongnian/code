    public IEnumerator<IGmxGlobal> GetEnumerator()
    {
        return (base as IEnumerator<GmxGlobal>).GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
