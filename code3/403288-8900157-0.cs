    static object AddTypeName(object o)
    {
        return new Dictionary<string, object> 
        {
            { o.GetType().Name.ToLowerInvariant(), o }
        };
    }
