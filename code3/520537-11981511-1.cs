    public void Foo<T>(...)
    {
        IEnumerable<T> keys = (IEnumerable<T>) p_info_keys.GetValue(obj, null);
        foreach (T key in keys)
        {
            ...
        }
    }
