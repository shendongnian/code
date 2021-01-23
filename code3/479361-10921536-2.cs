    public T Get<T>(string propertyName)
    {
        return Get<T>(propertyName, default(T));
    }
    public T Get<T>(string propertyName, T defaultValue)
    {
        object obj;
        if (propertyBag.TryGetValue(propertyName, out obj)) {
            return (T)obj;
        }
        return defaultValue;
    }
