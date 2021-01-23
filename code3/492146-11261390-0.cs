    private static bool OpenGenericIsAssignableFrom(
            Type openGenericType, 
            Type typeToCheck)
        {
                if (typeToCheck.IsGenericType && openGenericType.IsGenericType)
                {
                    var typeArgs = typeToCheck.GetGenericArguments();
                    if (typeArgs.Length == openGenericType.GetGenericArguments().Length){
                    {
                        try{
                           var closed = openGenericType.MakeGenericType(typeArgs);
                           return closed.IsAssignableFrom(typeToCheck);
                        } catch{
                           //violated type contraints
                           return false;
                        }
                    }
                }
            }
            return false;
        }
