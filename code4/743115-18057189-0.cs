    List<KeyValuePair<string, object>> GetEnumInfo(string name)
    {
    	var type = Type.GetType(name);
    	return Enum.GetValues(type)
    			.Cast<object>()
    			.Select(v => new KeyValuePair<string, object>(Enum.GetName(type, v), v))
    			.ToList();
    }
