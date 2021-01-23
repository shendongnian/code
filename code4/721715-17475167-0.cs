	public static bool IsExceptionBoundToType(FaultException fe, Type checkType)
	{
		bool isBound = false;
		Type feType = fe.GetType();
		if (feType.IsGenericType && feType.GetGenericTypeDefinition() == typeof(FaultException<>))
		{
			Type faultType = feType.GetGenericArguments()[0];
			isBound = checkType.IsAssignableFrom(faultType);
		}
		return isBound;
	}
