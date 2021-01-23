    private void SetObjectProperty(string propertyName, string value, object obj)
    {
        PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
        propertyInfo.SetValue(obj, value, null);
    }
