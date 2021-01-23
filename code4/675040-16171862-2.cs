    private ValueCollection valueCollection;
    public ValueCollection Values
    {
        get { return valueCollection; }
    }
    ICollection<TValue> IDictionary<TKey, TValue>.Values
    {
        get { return valueCollection; }
    }
