	public static void SomeMethod()
	{
		var container = new
		{
			toBeNulledObj1 = new ABC(),
			toBeNulledObj2 = new ABC(),
		};
		NullingFunction(container);
	}
	private static void NullingFunction<T>(T container)
		where T : class
	{
		if (container == null)
			return;
		foreach(FieldInfo f in container.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
			if (f.FieldType.IsClass)
				f.SetValue(container, null);
	}
