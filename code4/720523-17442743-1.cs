    public static string GetLabel(this PropertyInfo propertyInfo)
    {
        var meta = ModelMetadataProviders.Current.GetMetadataForProperty(null, propertyInfo.DeclaringType, propertyInfo.Name);
        return meta.GetDisplayName();
    }
    public static PropertyInfo[] VisibleProperties(this IEnumerable Model)
    {
        var elementType = Model.GetType().GetElementType();
        if (elementType == null)
        {
            elementType = Model.GetType().GetGenericArguments()[0];
        }
        return elementType.GetProperties().Where(info => info.Name != elementType.IdentifierPropertyName()).ToArray();
    }
    public static PropertyInfo[] VisibleProperties(this Object model)
    {
        return model.GetType().GetProperties().Where(info => info.Name != model.IdentifierPropertyName()).ToArray();
    }
