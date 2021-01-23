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
		if (invoke.ReturnType != typeof(void))
			throw new ArgumentException("Delegate is not allowed to return anything.");
		// Validate the signatures
		ParameterInfo[] constructorParams = constructor.GetParameters();
		ParameterInfo[] delegateParams = invoke.GetParameters();
		if (constructorParams.Length + 1 != delegateParams.Length)
			throw new ArgumentException("The number of arguments of the delegate must be one more as the number of arguments of the constructor.");
		if (delegateParams[0].ParameterType != constructor.DeclaringType)
			throw new ArgumentException("The first argument of the delegate must of the same type as the type the constructor is constructing.");
		if (delegateParams[0].IsOut)
			throw new ArgumentException("Output parameters are not supported.");
		for (int i = 0; i < constructorParams.Length; i++)
		{
			ParameterInfo constructorParam = constructorParams[i];
			ParameterInfo delegateParam = delegateParams[i + 1];
			if (constructorParam.ParameterType != delegateParam.ParameterType)
				throw new ArgumentException("Arguments of constructor and delegate do not match.");
			if (constructorParam.IsOut != delegateParam.IsOut)
				throw new ArgumentException("Output parameters are not supported.");
		}
		// Create the dynamic method.
		DynamicMethod method = new DynamicMethod(
				"",
				typeof(void),
				delegateParams.Select(p => p.ParameterType).ToArray(),
				constructor.DeclaringType.Module,
				true);
		// Create the IL.
		ILGenerator gen = method.GetILGenerator();
		for (int i = 0; i < delegateParams.Length; i++)
			gen.Emit(OpCodes.Ldarg, i);
		gen.Emit(OpCodes.Call, constructor);
		gen.Emit(OpCodes.Ret);
		// Return the delegate :)
		return (T)(object)method.CreateDelegate(delegateType);
	}
