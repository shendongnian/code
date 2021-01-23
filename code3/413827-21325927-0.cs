    Type itemType = item.GetType();
    try
    {
        PropertyInfo field = itemType.GetProperty(fieldName);
        object val = field.GetValue(item, null);
    }
    catch (Exception ex)
    {
        // field doesn't exist, do something else
    }
