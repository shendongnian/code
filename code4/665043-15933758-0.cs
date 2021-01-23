    CustomAttributeBuilder BuildCustomAttribute(System.Attribute attribute)
    {
        Type type = attribute.GetType();
        var constructor = type.GetConstructor(Type.EmptyTypes);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        var propertyValues = from p in properties
                             select p.GetValue(attribute, null);
        var fieldValues = from f in fields
                          select f.GetValue(attribute);
        return new CustomAttributeBuilder(constructor, 
                                         Type.EmptyTypes,
                                         properties,
                                         propertyValues.ToArray(),
                                         fields,
                                         fieldValues.ToArray());
    }
