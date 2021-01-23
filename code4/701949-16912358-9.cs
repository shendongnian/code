    object GetDefault(Type t)
    {
        if (t.IsValueType)
        {
            return Activator.CreateInstance(t);
        }
        else
        {
            return null;
        }
    }
