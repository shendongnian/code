    public static T1 CopyProperties<T1, T2>(T2 model)
        where T1 : new()
        where T2 : new()
    {
        // Get all the properties in the model
        var type = model.GetType();
        var properties = type.GetProperties();
        var result = new T1();
        var resultType = result.GetType();
        var resultProperties = resultType.GetProperties();
        // Loop through each property
        foreach (var property in properties)
        {
            var resultProperty = resultProperties.FirstOrDefault(n => n.Name == property.Name && n.PropertyType == property.PropertyType);
            if (resultProperty != null)
            {
                resultProperty.SetValue(result, property.GetValue(model, null), null);
            }
        }
        return result;
    }
