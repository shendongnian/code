    foreach (PropertyInfo property in properties)
    {
        if (property.IsDefined(typeof(FieldMapAttribute), false))
        {
            colName = property.GetCustomAttributes(typeof(FieldMapAttribute), false)
                              .First()
                              .DbColumnName;
        }
    }
