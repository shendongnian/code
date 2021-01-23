    private static void SetPropValue(object src, string collection, int index, 
                                     string property, string value)
    {
        PropertyInfo collectionProperty = src.GetType().GetProperty(collection);
        Array array = collectionProperty.GetValue(src, null) as Array;
        object item = array.GetValue(index);
        SetPropValue(item, property, value);
    }
