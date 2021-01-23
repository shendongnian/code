    public bool IsKeyValuePair(object o) 
    {
        Type type = o.GetType();
        
        if (type.IsGenericType)
        {
            return type.GetGenericTypeDefinition() != null ? type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>) : false;
        }
        
        return false;
    }
