    public bool IsList(object o)
    {
        var type = o.GetType();
        return o is IList &&
               type.IsGenericType &&
               type.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
    }
    public bool IsDictionary(object o)
    {
        var type = o.GetType();
        return o is IDictionary &&
               type.IsGenericType &&
               type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
    }
    
        
