    if (PossibleValues != null)
    {
        var genericEnumerableInterface = PossibleValues
            .GetType()
            .GetInterfaces()
            .Where(i => i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .FirstOrDefault();
        if (genericEnumerableInterface == null)
        {
            //throw here, or return null, or do something else
        }
        var elementType = genericEnumerableInterface.GetGenericArguments()[0];
        return elementType.GetGenericTypeDefinition() == typeof(Nullable<>)
            ? elementType.GetGenericArguments[0]
            : elementType;
        //...
