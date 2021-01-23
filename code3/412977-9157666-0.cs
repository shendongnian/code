    public static IQueryable CreateQueryInstance(Type queryType) 
    {
        var genericQueryTypeDefinition = typeof(XPQuery<>);
        var queryTypeArguments = new[] { typeof(queryType) };
        var genericQueryType = genericQueryTypeDefinition.MakeGenericType(queryTypeArguments);
        var queryObject = (IQueryable)Activator.CreateInstance(genericQueryType, <your parameters here>);
        
        return queryObject;
    }
