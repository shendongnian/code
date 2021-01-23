    public static MethodInfo MakeGenericMethod<TSourceType>(Type genericArgument, string methodName, Type[] parameterTypes, params int[] indexesWhereParameterIsTheGenericArgument)
    {
        //Get the type of the thing we're looking for the method on
        var sourceType = typeof (TSourceType);
        //Get all the methods that match the default binding flags
        var allMethods = sourceType.GetMethods();
        //Get all the methods with the same names
        var candidates = allMethods.Where(x => x.Name == methodName);
        
        //Find the appropriate method from the set of candidates
        foreach (var candidate in candidates)
        {
            //Look for methods with the same number of parameters and same types 
            //   of parameters (excepting for ones that have been marked as 
            //   replaceable by the generic parameter)
            var parameters = candidate.GetParameters();
            var successfulMatch = parameters.Length == parameterTypes.Length;
            if (successfulMatch)
            {
                for (var i = 0; i < parameters.Length; ++i)
                {
                    successfulMatch &= parameterTypes[i] == parameters[i].ParameterType || indexesWhereParameterIsTheGenericArgument.Contains(i);
                }
            }
            //If all the parameters were validated, make the generic method and return it
            if (successfulMatch)
            {
                return candidate.MakeGenericMethod(genericArgument);
            }
        }
        //We couldn't find a suitable candidate, return null
        return null;
    }
