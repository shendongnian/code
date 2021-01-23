	public static string RunAttributeConstructor<TType>(TType value)
	{
		Type type = value.GetType();
		var attributes = type.GetCustomAttributes(typeof(TestClassAttribute), false);
	}
