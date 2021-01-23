    public bool PropertyExists<T>(string propertyName, IEnumerable<string> propertyList,T obj)
    {
	    string test = obj.GetType().GetProperty(propertyName) == null ? "" : obj.GetType().GetProperty(propertyName).Name;
    	bool result = propertyList.Contains(test);
	    return result;
    }
