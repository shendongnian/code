    public object[] ToPropertyArray(object o)
    {
        return o.GetType.GetProperties()
            .Select(p => p.GetValue(o, null))
            .ToArray();
    }
