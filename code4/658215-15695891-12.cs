	public void InitializeSubscribers()
	{
		foreach (object subscriber in
			from assembly in AppDomain.CurrentDomain.GetAssemblies()
			from type in assembly.GetTypes()
			where !type.IsAbstract && type.IsClass && !type.ContainsGenericParameters &&
			      type.GetInterfaces().Any(t => t.IsGenericType &&
			                                    t.GetGenericTypeDefinition() == typeof (IEventSubscriber<>))
			select type.GetConstructor(new Type[0])
			into constructorInfo
			where constructorInfo != null
			select constructorInfo.Invoke(new object[0]))
		{
			Subscribe((dynamic) subscriber);
		}
	}
