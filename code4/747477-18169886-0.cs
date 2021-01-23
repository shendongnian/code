    public IEnumerator<string> GetEnumerator()
    {
        // Whatever
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
