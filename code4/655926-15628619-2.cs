    public static T EmptyModel<T>(ref T model) where T : new()
    {
        foreach (PropertyInfo property in typeof(T).GetProperties())
        {
            Type myType = property.PropertyType;
            var constructor = myType.GetConstructor(Type.EmptyTypes);
            if (constructor != null)
            {
                // will initialize to a new copy of property type
                property.SetValue(model, constructor.Invoke(null));
                // or property.SetValue(model, Activator.CreateInstance(myType));
            }
            else
            {
                // will initialize to the default value of property type
                property.SetValue(model, null);
            }
        }
    }
