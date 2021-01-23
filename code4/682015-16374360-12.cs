	static public T CreateDelegate<T>(this ConstructorInfo constructor)
	{
		// Validate if the constructor is not null.
		if (constructor == null)
			throw new ArgumentNullException("constructor");
		// Validate if T is a delegate.
		Type delegateType = typeof(T);
		if (!typeof(Delegate).IsAssignableFrom(delegateType))
			throw new ArgumentException("Generic argument T must be a delegate.");
		// Get alle needed information.
		MethodInfo invoke = delegateType.GetMethod("Invoke");
		ParameterInfo[] constructorParams = constructor.GetParameters();
		ParameterInfo[] delegateParams = invoke.GetParameters();
		// What kind of delegate is going to be created (open, creational, static).
		bool isOpen = false;
		OpCode opCode = OpCodes.Newobj;
		int parameterOffset = 0;
		if (constructor.IsStatic) // Open delegate.
		{
			opCode = OpCodes.Call;
			if (invoke.ReturnType != typeof(void))
				throw new ArgumentException("Delegate to static constructor cannot have a return type.");
			if (delegateParams.Length != 0)
				throw new ArgumentException("Delegate to static constructor cannot have any parameters.");
		}
		else if (invoke.ReturnType == typeof(void)) // Open delegate.
		{
			opCode = OpCodes.Call;
			isOpen = true;
			parameterOffset = 1;
			if ((delegateParams.Length == 0) || (delegateParams[0].ParameterType != constructor.DeclaringType))
				throw new ArgumentException("An open delegate must have a first argument of the same type as the type that is being constructed.");
		}
		else // Creational delegate.
		{
			if (invoke.ReturnType != constructor.DeclaringType)
				throw new ArgumentException("Return type of delegate must be equal to the type that is being constructed.");
		}
		// Validate the parameters (if any).
		if (constructorParams.Length + parameterOffset != delegateParams.Length)
			throw new ArgumentException(isOpen
				? "The number of parameters of the delegate (the argument for the instance excluded) must be the same as the number of parameters of the constructor."
				: "The number of parameters of the delegate must be the same as the number of parameters of the constructor.");
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
		gen.Emit(opCode, constructor);
		gen.Emit(OpCodes.Ret);
		// Return the delegate :)
		return (T)(object)method.CreateDelegate(delegateType);
	}
