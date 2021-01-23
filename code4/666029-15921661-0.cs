    PropertyInfo[] propertyInfos = typeof(Project).GetProperties();
    
    foreach (PropertyInfo propertyInfo in propertyInfos)
    {
        // ...
        if(propertyInfo.PropertyType == typeof(MyCustomClass))
            // ...
    }
