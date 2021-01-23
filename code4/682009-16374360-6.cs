	static public T CreateDelegate<T>(this ConstructorInfo constructor)
	{
		// Validate if the constructor is not null.
		if (constructor == null)
			throw new ArgumentNullException("constructor");
		// Validate if the constructor is not null.
		if (constructor.IsStatic)
			throw new ArgumentException("Constructor is not allowed to be a static constructor.");
		// Validate if T is a delegate.
		Type delegateType = typeof(T);
		if (!typeof(Delegate).IsAssignableFrom(delegateType))
			throw new ArgumentException("Generic argument T must be a delegate.");
		// Validate the delegate return type
		MethodInfo invoke = delegateType.GetMethod("Invoke");
		bool isOpen;
		int parameterOffset;
		if (invoke.ReturnType == constructor.DeclaringType)
		{
			isOpen = false;
			parameterOffset = 0;
		}
		else if (invoke.ReturnType == typeof(void))
		{
			isOpen = true;
			parameterOffset = 1;
		}
		else 
			throw new ArgumentException("Delegate is not allowed to return anything.");
		// Validate the signatures
		ParameterInfo[] constructorParams = constructor.GetParameters();
		ParameterInfo[] delegateParams = invoke.GetParameters();
		if (constructorParams.Length + parameterOffset != delegateParams.Length)
			throw new ArgumentException(isOpen
				? "The number of parameters of the delegate (the argument for the instance excluded) must be the same as the number of parameters of the constructor."
				: "The number of parameters of the delegate must be the same as the number of parameters of the constructor.");
		if (isOpen && delegateParams[0].ParameterType != constructor.DeclaringType)
			throw new ArgumentException("The first argument of the delegate must of the same type as the type the constructor is constructing.");
		for (int i = 0; i < constructorParams.Length; i++)
		{
			ParameterInfo constructorParam = constructorParams[i];
			ParameterInfo delegateParam = delegateParams[i + parameterOffset];
			if (constructorParam.ParameterType != delegateParam.ParameterType)
				throw new ArgumentException("Arguments of constructor and delegate do not match.");
		}
		// Create the dynamic method.
		DynamicMethod method = new DynamicMethod(
				"",
				invoke.ReturnType,
				delegateParams.Select(p => p.ParameterType).ToArray(),
				constructor.DeclaringType.Module,
				true);
		// Create the IL.
		ILGenerator gen = method.GetILGenerator();
		for (int i = 0; i < delegateParams.Length; i++)
			gen.Emit(OpCodes.Ldarg, i);
		gen.Emit(isOpen ? OpCodes.Call : OpCodes.Newobj, constructor);
		gen.Emit(OpCodes.Ret);
		// Return the delegate :)
		return (T)(object)method.CreateDelegate(delegateType);
	}
