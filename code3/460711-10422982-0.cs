    foreach (var property in context.GetType().GetProperties())
    {
        if (property.PropertyType.IsGenericType)
        {
            var genericArguments = property.PropertyType.GetGenericArguments();
            //Do something with the generic parameter types                
        }
    }
