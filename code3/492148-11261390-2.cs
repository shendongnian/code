    private static bool OpenGenericIsAssignableFrom(
            Type openGenericType, 
            Type typeToCheck)
        {
                if (!openGenericType.IsGenericType || typeToCheck == null) return false;
                if(typeToCheck.IsGenericType)
                {
                    var typeArgs = typeToCheck.GetGenericArguments();
                    if (typeArgs.Length == openGenericType.GetGenericArguments().Length){
                    {
                        try{
                           var closed = openGenericType.MakeGenericType(typeArgs);
                           if( closed.IsAssignableFrom(typeToCheck)) return true;
                        } catch{
                           //violated type contraints
                        }
                    }
                } else {
                    return OpenGenericIsAssignableFrom(
                                   openGenericType,
                                   typeToCheck.BaseType) 
                           || typeToCheck.GetInterfaces().Any(i=> 
                                 OpenGenericIsAssignableFrom(
                                   openGenericType,
                                   i);
                }
            }
            return false;
        }
