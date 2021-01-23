	var dictStr = new Dictionary<string, List<string>>();
	foreach(var element in collection)
	{
		List<string> values;
		if(!dictStr.TryGetValue(element.Property, out values))
		{
			values = new List<string>();
			dictStr.Add(element.Property, values);
		}
		values.Add(element.Value);
	}
