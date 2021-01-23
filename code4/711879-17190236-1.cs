    public bool IsList(object o)
    {
        return o is IList &&
               o.GetType().IsGenericType &&
               o.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
    public bool IsDictionary(object o)
    {
        return o is IDictionary &&
               o.GetType().IsGenericType &&
               o.GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<>));
    }
    
        
