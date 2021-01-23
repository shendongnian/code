    private XmlRootAttribute XmlRootForCollection(Type type)
    {
        XmlRootAttribute result = null;
        Type typeInner = null;
        if(type.IsGenericType)
        {
            var typeGeneric = type.GetGenericArguments()[0];
            var typeCollection = typeof (ICollection<>).MakeGenericType(typeGeneric);
            if(typeCollection.IsAssignableFrom(type))
                typeInner = typeGeneric;
        }
        else if(typeof (ICollection).IsAssignableFrom(type)
            && type.HasElementType)
        {
            typeInner = type.GetElementType();
        }
        // yeepeeh ! if we are working with a collection
        if(typeInner != null)
        {
            var attributes = typeInner.GetCustomAttributes(typeof (XmlTypeAttribute), true);
            if((attributes != null)
                && (attributes.Length > 0))
            {
                var typeName = (attributes[0] as XmlTypeAttribute).TypeName + 's';
                result = new XmlRootAttribute(typeName);
            }
        }
        return result;
    }
