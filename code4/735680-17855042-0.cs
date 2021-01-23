    public bool PropertyExists<T>(string PropertyName, List<string> PropertyList,T obj)
    {
    	string test = obj.GetType().GetProperty(PropertyName) == null ? "" : obj.GetType().GetProperty(PropertyName).Name;
    	bool result = PropertyList.Contains(test);
    	return result;
    }
