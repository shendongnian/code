    public T Get<T>(string propertyName)
    {
        object obj;
        if (propertyBag.TryGetValue(propertyName, out obj)) {
            return (T)obj;
        }
        return default(T);
    }
