    T MapToClass<T>(SqlDataReader reader) where T : class
    {
        T returnedObject = Activator.CreateInstance<T>();
        PropertyInfo[] modelProperties = returnedObject.GetType().GetProperties();
        for (int i = 0; i < modelProperties.Length; i++)
            modelProperties[i].SetValue(returnedObject, Convert.ChangeType(reader.GetValue(i), modelProperties[i].PropertyType), null);
        return returnedObject;
    }
