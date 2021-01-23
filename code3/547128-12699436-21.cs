    class MasterClass
    {
    	Dictionary<string, HookObj> dict = new Dictionary<string, HookObj>();
    
    	//Data came in from an external source, see if we know what variable to assign the value to
    	public void receiveData(string key, string value)
    	{
    		if (dict.ContainsKey(key))
    			assignVal(dict[key], value);
    		else
    			throw new NotImplementedException(); //use NotImplementedException as placeholder until we make proper exception
    	}
    	
    	//Cast the value-string to the proper type and assign it
    	private void assignVal(HookObj hookobj, string value)
    	{
    		hookobj.SetValue(value);
    	}
    	
    	protected void RegisterProperty<T>(Action<T> setter, Func<T> getter, string name, Func<string, T> inputParser)
    	{
    		var hook = new CustomHook<T>(inputParser);
    		hook.SetSetter(setter);
    		hook.SetGetter(getter);
    		dict.Add(name, hook);
    	}
    	
    	protected void RegisterProperty(Action<string> setter, Func<string> getter, string name)
    	{
    		var hook = new StringHook();
    		hook.SetSetter(setter);
    		hook.SetGetter(getter);
    		dict.Add(name, hook);
    	}
    	
    	protected void RegisterProperty(Action<int> setter, Func<int> getter, string name)
    	{
    		var hook = new IntHook();
    		hook.SetSetter(setter);
    		hook.SetGetter(getter);
    		dict.Add(name, hook);
    	}
    	
    	protected void RegisterProperty(Action<float> setter, Func<float> getter, string name)
    	{
    		var hook = new FloatHook();
    		hook.SetSetter(setter);
    		hook.SetGetter(getter);
    		dict.Add(name, hook);
    	}
    }
