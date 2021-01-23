    public T Convert<T>(ExpandoObject source, T example)
    	where T : class
    {
    	IDictionary<string, object> dict = source;
    	
    	var ctor = example.GetType().GetConstructors().Single();
    	
    	var parameters = ctor.GetParameters();
    	
    	var parameterValues = parameters.Select(p => dict[p.Name]).ToArray();
    	
    	return  (T)ctor.Invoke(parameterValues);
    }
