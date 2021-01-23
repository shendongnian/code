	protected void RegisterProperty<T>(Action<T> setter, Func<T> getter, string name, HookObj<T> hook)
	{
		hook.SetSetter(setter);
		hook.SetGetter(getter);
		dict.Add(name, hook);
	}
	
	protected void RegisterProperty<T>(Action<T> setter, Func<T> getter, string name, Func<string, T> inputParser)
	{
		var hook = new CustomHook<T>(inputParser);
		RegisterProperty(setter, getter, name, hook);
	}
	
	protected void RegisterProperty(Action<string> setter, Func<string> getter, string name)
	{
		var hook = new StringHook();
		RegisterProperty(setter, getter, name, hook);
	}
	
	protected void RegisterProperty(Action<int> setter, Func<int> getter, string name)
	{
		var hook = new IntHook();
		RegisterProperty(setter, getter, name, hook);
	}
	
	protected void RegisterProperty(Action<float> setter, Func<float> getter, string name)
	{
		var hook = new FloatHook();
		RegisterProperty(setter, getter, name, hook);
	}
