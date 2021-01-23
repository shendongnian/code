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
    		try
    		{
    			if (hookobj.theType == typeof(string))
    				hookobj.SetValue(value);
    			else if (hookobj.theType == typeof(int))
    				hookobj.SetValue(Int32.Parse(value));
    			else if (hookobj.theType == typeof(float))
    				hookobj.SetValue(float.Parse(value));
    			else
    				throw new NotImplementedException();
    		}
    		catch (RuntimeBinderException ex) { throw new NotImplementedException("", ex); }
    		catch (System.FormatException ex) { throw new NotImplementedException("", ex); }
    	}
    	
    	protected void newHookAndAdd<T>(Action<T> setter, Func<T> getter, string name)
    	{
    		HookObj hook = new HookObj<T>(setter, getter);
    		dict.Add(name, hook);
    	}
    }
