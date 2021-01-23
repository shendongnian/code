    private void SetObjectProperty(string propertyName, string value, object obj)
    {
        PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
        // make sure object has the property we are after
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(obj, value, null);
        }
    }
