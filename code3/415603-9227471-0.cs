	var types = new Queue<Type>();
	var props = new List<PropertyInfo>();
	types.Enqueue(typeof(Nested2));
	
	while (types.Count > 0) {
		Type t = types.Dequeue();
		foreach (var prop in t.GetProperties()) {
            if (props.Contains(prop)) { continue; }
			props.Add(prop);
			if (IsCustomType(prop.PropertyType)) { types.Enqueue(prop.PropertyType); }
		}
	}
