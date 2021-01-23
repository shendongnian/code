    if(type.IsGenericType &&
         type.GetGenericTypeDefinition() == typeof(MyGeneralClass<>))
    {
       Type firstArg = type.GetGenericArguments()[0];
    }
