    public static T EmptyModel<T>(ref T model) where T : new()
    {
        foreach (PropertyInfo property in typeof(T).GetProperties())
        {
            Type myType = property.PropertyType;
            property.SetValue(model, Activator.CreateInstance(myType));
        }
    }
