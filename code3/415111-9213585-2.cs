    public static T Get<T>() where T : InterfaceBase
    {
        Type type = typeof(T);
        if (t.IsAbstract || t.IsInterface)
	{
            throw new ArgumentException(@"Only non-abstract classes supported as T type parameter.");
	}
        return Activator.CreateInstance<T>();
    }
		
