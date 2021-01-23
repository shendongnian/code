    var type = referenceToList.GetType();
    if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
    {
        // It's some List<T>
    }
