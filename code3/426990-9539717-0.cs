    public bool IsClassMapping(Type t)
    {
        while (t != null)
        {
            if (t.IsGenericType &&
                t.GetGenericTypeDefinition() == typeof(ClassMapping<>))
            {
                return true;
            }
            t = t.BaseType;
        }
        return false;
    }
