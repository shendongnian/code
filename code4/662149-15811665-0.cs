    Type type = typeof(TEntityTrack);
    while (type != typeof(object))
    {
        Type[] genericTypes = type.GetGenericArguments();
        if (genericTypes.Length == 0)
        {
            type = type.BaseType;
        }
        else
        {
            Type entityType = genericTypes[0];
            return entityType;
        }
    }
    // Throw an exception or other appropriate action
    throw Exception("Does not have generic argument.");
