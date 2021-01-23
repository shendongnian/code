    public void GetPropertyValue(object o, string path)
    {
        var propertyNames = path.Split('.');
        var value = o.GetType().GetProperty(propertyNames[0]).GetValue(o, null);
    
        if (propertyNames.Length == 1 || value == null)
            return value;
        else
        {
            return GetPropertyValue(value, path.Replace(propertyNames[0] + ".", ""));
        }
    }
