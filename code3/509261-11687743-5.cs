    T MapToClass<T>(SqlDataReader reader) where T : class
    {
            T returnedObject = Activator.CreateInstance<T>();
            PropertyInfo[] modelProperties = returnedObject.GetType().GetProperties();
            for (int i = 0; i < modelProperties.Length; i++)
            {
                MappingAttribute[] attributes = modelProperties[i].GetCustomAttributes<MappingAttribute>(true).ToArray();
                if (attributes.Length > 0 && attributes[0].ColumnName != null)
                    modelProperties[i].SetValue(returnedObject, Convert.ChangeType(reader[attributes[0].ColumnName], modelProperties[i].PropertyType), null);
            }
            return returnedObject;
    }
