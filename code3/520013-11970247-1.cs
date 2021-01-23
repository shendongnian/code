	var merged = props.First();
	foreach (var prop in props.Skip(1))
	{
		foreach (var key in prop.Keys)
		{
			dynamic oldValue;
			if (merged.TryGetValue(key, out oldValue))
			{
				if (oldValue is IList<dynamic>)
					merged[key].Add(prop[key]);
				else
					merged[key] = new List<dynamic> { oldValue, prop[key] };
			}
			else
				merged.Add(key, prop[key]);
		}
	}
