    public static Type GetDelegateType (this MethodInfo methodInfo)
    {
      var parameterTypes = methodInfo.GetParameters ().Select (x => x.ParameterType);
      var returnType = new[] { methodInfo.ReturnType };
      var delegateTypes = parameterTypes.Concat (returnType).ToArray ();
      return Expression.GetDelegateType (delegateTypes);
    } 
