    public T GetValue<T>(string name, T ifNull) where T : IConvertible
    {
        string value = GetProperty(name);
        if (value == null)
            return ifNull;
        try
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        catch
        {
            return ifNull;
        }
    }
