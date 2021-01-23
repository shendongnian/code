    T MapToClass<T>(SqlDataReader reader) where T : class
    {
            T returnedObject = Activator.CreateInstance<T>();
            List<PropertyInfo> modelProperties = returnedObject.GetType().GetProperties().OrderBy(p => p.MetadataToken).ToList();
            for (int i = 0; i < modelProperties.Count; i++)
                modelProperties[i].SetValue(returnedObject, Convert.ChangeType(reader.GetValue(i), modelProperties[i].PropertyType), null);
            return returnedObject;
    }
