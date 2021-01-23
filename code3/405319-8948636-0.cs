    PropertyInfo[] propCollection = type.GetProperties();
    foreach (PropertyInfo property in propCollection)
    {
        foreach (var attribute in property.GetCustomAttributes(true))
        {
            if (attribute is ColumnName)
            {
            }
        }
    }
