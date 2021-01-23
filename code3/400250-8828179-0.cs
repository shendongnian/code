    public object ExecuteMethod(string moduleName, string methodName, object[] arguments)
    {
      CmsModuleMethodInfo methodInfo = CmsModuleManager.GetModuleMethod(moduleName, methodName);
      ...
    
      ParameterInfo[] paramInfo = methodInfo.Method.GetParameters();
      Object[] parameters = new Object[paramInfo.Length];
      Type[] paramTypes = paramInfo.Select(x => x.ParameterType).ToArray();
      for (int i = 0; i < parameters.Length; ++i)
      {
        Type paramType = paramTypes[i];
        Type passedType = (arguments[i] != null) ? arguments[i].GetType() : null;
    
        if (paramType.IsArray)
        {
          // Workaround for InvokeMethod which is very strict about arguments.
          // For example, "int[]" is casted as System.Object[] and
          // InvokeMethod raises an exception in this case.
          // So, convert any object which is an Array actually to a real Array.
          int n = ((Array)arguments[i]).Length;
          parameters[i] = Array.CreateInstance(paramType.GetElementType(), n);
          Array.Copy((Array)arguments[i], (Array)parameters[i], n);
        }
        else if ((passedType == typeof(System.Int32)) && (paramType.IsEnum))
        {
          parameters[i] = Enum.ToObject(paramType, (System.Int32)arguments[i]);
        }
        else
        {
          // just pass it as it's
          parameters[i] = Convert.ChangeType(arguments[i], paramType);
        }
      }
    
      object result = null;
      try
      {
        result = methodInfo.Method.Invoke(null, parameters);
      }
      catch (TargetInvocationException e)
      {
        if (e.InnerException != null)
        {
          throw e.InnerException;
        }
      }
     
      return result;
    }
