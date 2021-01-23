    public bool IsList(object o)
    {
        return o is IList &&
               o.GetType().IsGenericType &&
               o.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
    
        
