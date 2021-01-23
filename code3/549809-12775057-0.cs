    public virtual T Find(params object[] keyValues)
    {
        if (keyValues.Length != _keyProperties.Count)
            throw new ArgumentException("Incorrect number of keys passed to find method");
    
        IQueryable<T> keyQuery = this.AsQueryable<T>();
        for (int i = 0; i < keyValues.Length; i++)
        {
            var x = i; // nested linq
            keyQuery = keyQuery.
            Where(entity => _keyProperties[x].GetValue(entity, null).Equals(keyValues[x]));
        }
    
        return keyQuery.SingleOrDefault();
    }
