    PropertyInfo info = t.GetProperty("Value");
    object value = null;
    try 
    { 
        value = System.Convert.ChangeType(123, 
            Nullable.GetUnderlyingType(info.PropertyType));
    } 
    catch (InvalidCastException)
    {
        return;
    }
    propertyInfo.SetValue(obj, value, null);
