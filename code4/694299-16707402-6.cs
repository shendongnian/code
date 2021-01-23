	public static void SomeMethod()
	{
		var nullableObjects = new
                  {
			toBeNulledObj1 = new ABC(),
			toBeNulledObj2 = new ABC(),
		};
		NullingFunction(nullableObjects);
	}
	private static void NullingFunction<T>(T o)
		where T : class
	{
		if (o == null)
			return;
		foreach(FieldInfo f in o.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
			if (f.FieldType.IsClass)
				f.SetValue(o, null);
	}
