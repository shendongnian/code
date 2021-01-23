    Type GetBaseType(Type type)
    {
       while (type.BaseType != null)
       {
          type = type.BaseType;
          if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(BaseClass<>))
          {
              return type.GetGenericArguments()[0];
          }
       }
       throw new InvalidOperationException("Base type was not found");
    }
    
    // to use:
    GetBaseType(typeof(DerivedClass))
