    private static bool OpenGenericIsAssignableFrom(
        Type openGenericType, 
        Type typeToCheck)
    {
        if (!openGenericType.IsGenericType || typeToCheck == null) return false;
    
        if(typeToCheck.IsGenericType)
        {
            var typeArgs = typeToCheck.GetGenericArguments();
            if (typeArgs.Length == openGenericType.GetGenericArguments().Length)
            {
                try
                {
                  var closed = openGenericType.MakeGenericType(typeArgs);
                  return closed.IsAssignableFrom(typeToCheck);
                }
                catch
                {
                  //violated type contraints
                  return false
                }
            }
        }
        else 
        {
            return OpenGenericIsAssignableFrom(openGenericType, typeToCheck.BaseType) 
                  || typeToCheck.GetInterfaces()
                        .Any(i=> OpenGenericIsAssignableFrom(openGenericType,i));
        }
    }
