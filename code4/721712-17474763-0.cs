    public static bool IsExceptionBoundToType(FaultException fe, Type checkType)
    {
       bool isBound = false;
       // Check to see if the FaultException is a generic type.
       Type feType = fe.GetType();
       if (feType.IsGenericType && feType.GetGenericTypeDefinition() == typeof(FaultException<>))
       {
          // Check to see if the Detail property is a class of the specified type.
          PropertyInfo detailProperty = feType.GetProperty("Detail");
          if (detailProperty != null)
          {
             object detail = detailProperty.GetValue(fe, null);
             isBound = checkType.IsAssignableFrom(detail.GetType());
          }
       }
 
       return (isBound);
    }
