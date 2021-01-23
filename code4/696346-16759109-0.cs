    Type t = values[1].GetType();
    if(t.IsGenericType && 
    	t.GetGenericTypeDefinition() == typeof(DataWrapper<>) && 
    	typeof(IObject).IsAssignableFrom(t.GetGenericArguments()[0]))
    {
    	itemToAdd = (IObject)t.GetProperty("Data").GetValue(value[0], null)
    }
