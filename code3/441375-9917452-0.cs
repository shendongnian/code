    public static bool ImplementsAny(this object obj, params Type[] types)
    {
        foreach(var type in types)
        {
            if(type.IsAssignableFrom(obj.GetType())
                return true;
        }
        return false;
    }
