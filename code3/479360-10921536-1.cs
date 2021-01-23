    public T Get<T>(string propertyName)
    {
        object obj;
        if (propertyBag.TryGetValue(propertyName, out obj)) {
            return (T)obj;
        }
        if(typeof(T) == typeof(string)) {
            return String.Empty;
        }
        return default(T);
    }
