	static public T CreateConstructorDelegate<T>(this Type type)
	{
		// Validate if the constructor is not null.
		if (type == null)
			throw new ArgumentNullException("type");
		// Validate if T is a delegate.
		Type delegateType = typeof(T);
		if (!typeof(Delegate).IsAssignableFrom(delegateType))
			throw new ArgumentException("Generic argument T must be a delegate.");
		// Validate the delegate return type
		MethodInfo invoke = delegateType.GetMethod("Invoke");
		int parameterOffset = 0;
		BindingFlags binding = BindingFlags.Public | BindingFlags.Instance;
		if (invoke.ReturnType == typeof(void))
		{
			if (invoke.GetParameters().Length == 0)
				binding = BindingFlags.NonPublic | BindingFlags.Static; // For static constructors.
			else
				parameterOffset = 1; // For open delegates.
		}
		// Validate the signatures
		ParameterInfo[] delegateParams = invoke.GetParameters();
		ConstructorInfo constructor = type.GetConstructor(binding, null, delegateParams.Skip(parameterOffset).Select(p => p.ParameterType).ToArray(), null);
		if (constructor == null)
			throw new ArgumentException("Constructor with specified parameters cannot be found.");
		return constructor.CreateDelegate<T>();
	}
