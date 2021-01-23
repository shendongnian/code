	public static Delegate CreateDelegate(Type delegateType, Type objectType, string methodName)
	{
		var delegateMethod		= delegateType.GetMethod("Invoke");
		var delegateReturn		= delegateMethod.ReturnType;
		var delegateParameters	= delegateMethod.GetParameters();
		var methods				= objectType.GetMethods();
		MethodInfo method = null;
		ParameterInfo[] methodParameters = null;
		Type methodReturn = null;
		// find correct method by argument count
		foreach(var methodInfo in methods)
		{
			if(methodInfo.Name != methodName)
			{
				continue;
			}
			methodParameters = methodInfo.GetParameters();
			methodReturn = methodInfo.ReturnType;
			if(methodParameters.Length != delegateParameters.Length)
			{
				continue;
			}
			method = methodInfo;
		}
		if(method == null)
		{
			throw new Exception("Method not found");
		}
		if(method.IsGenericMethodDefinition)
		{
			var genericArguments	= method.GetGenericArguments();
			var genericParameters	= new Type[genericArguments.Length];
			int genericArgumentIndex = Array.IndexOf(genericArguments, methodReturn);
			if(genericArgumentIndex != -1)
			{
				genericParameters[genericArgumentIndex] = delegateReturn;
			}
			for(int i = 0; i < methodParameters.Length; ++i)
			{
				var methodParameter = methodParameters[i];
				genericArgumentIndex = Array.IndexOf(genericArguments, methodParameter.ParameterType);
				if(genericArgumentIndex == -1) continue;
				genericParameters[genericArgumentIndex] = delegateParameters[i].ParameterType;
			}
			if(Array.IndexOf(genericParameters, null) != -1)
			{
				throw new Exception("Failed to resolve some generic parameters.");
			}
			var concreteMethod = method.MakeGenericMethod(genericParameters);
			return Delegate.CreateDelegate(delegateType, concreteMethod);
		}
		else
		{
			return Delegate.CreateDelegate(delegateType, method);
		}
	}
