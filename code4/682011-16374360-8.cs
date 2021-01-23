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
		int parameterOffset = invoke.ReturnType == typeof(void) ? 1 : 0;
		// Validate the signatures
		ParameterInfo[] delegateParams = invoke.GetParameters();
		ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, delegateParams.Skip(parameterOffset).Select(p => p.ParameterType).ToArray(), null);
		if (constructor == null)
			throw new ArgumentException("Constructor with specified parameters cannot be found.");
		return constructor.CreateDelegate<T>();
	}
