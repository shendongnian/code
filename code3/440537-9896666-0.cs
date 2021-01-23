    private static Dictionary<Type, Func<string,object>> conversionMap = new Dictionary<Type, Func<string,object>> 
    { 
        {typeof(EntityA), TransformXmlToEntityA},
        {typeof(EntityB), TransformXmlToEntityB},
        // ....
    }
    public static T TransformXmlToEntity<T>(string xml) 
    {
        return (T)conversionMap[typeof(T)](xml);
    }
