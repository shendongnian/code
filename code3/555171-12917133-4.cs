	private static dynamic CreateNewDynamicObject(
		string name, string lastName, string comment, Dictionary<string, string> customProperties)
	{
		dynamic obj = new ExpandoObject();
		obj.Name = name;
		obj.LastName = lastName;
		obj.Comment = comment;
		foreach (var prop in customProperties)
			(obj as IDictionary<string, Object>).Add(prop.Key, prop.Value ?? "");
		return obj;
	}
