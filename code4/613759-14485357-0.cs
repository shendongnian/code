    public static PropertyInfo PropertyInfoFromAccessor(MethodInfo accessor)
    {
       PropertyInfo result = null;
       if (accessor != null && accessor.IsSpecialName)
       {
          string propertyName = accessor.Name;
          if (propertyName != null && propertyName.Length >= 5)
          {
             Type[] parameterTypes;
             Type returnType = accessor.ReturnType;
             ParameterInfo[] parameters = accessor.GetParameters();
             int parameterCount = (parameters == null ? 0 : parameters.Length);
    
             if (returnType == typeof(void))
             {
                if (parameterCount == 0)
                {
                   returnType = null;
                }
                else
                {
                   parameterCount--;
                   returnType = parameters[parameterCount].ParameterType;
                }
             }
    
             if (returnType != null)
             {
                parameterTypes = new Type[parameterCount];
                for (int index = 0; index < parameterTypes.Length; index++)
                {
                   parameterTypes[index] = parameters[index].ParameterType;
                }
    
                try
                {
                   result = accessor.DeclaringType.GetProperty(
                      propertyName.Substring(4),
                      returnType,
                      parameterTypes);
                }
                catch (AmbiguousMatchException)
                {
                }
             }
          }
       }
    
       return result;
    }
