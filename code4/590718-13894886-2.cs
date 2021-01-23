    private static Type GetListItemType(Type listType)
    {
        Type itemType = null;
        foreach (Type interfaceType in listType.GetInterfaces()) {
            if (interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition() == typeof(IList<>)) {
                itemType = interfaceType.GetGenericArguments()[0];
                break;
            }
        }
        return itemType;
    }
