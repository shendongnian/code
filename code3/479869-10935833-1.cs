	public static IDictionary<string, string> GetProperties<T>(this T obj)
		where T : class
	{
		var properties = obj.GetPropertyList();
		return properties.ToDictionary(prop => prop.Item1, prop => prop.Item2);
	}
	public static IEnumerable<Tuple<string, string>> GetPropertyList<T>(this T obj)
		where T : class
	{
		if (obj == null)
			throw new ArgumentNullException("obj");
		Type t = obj.GetType();
		return GetProperties(obj, t, t.Name);
	}
	private static IEnumerable<Tuple<string, string>> GetProperties(object obj, Type objType, string propertyPath)
	{
		// If atomic property, return property value with path to property
		if (objType.IsValueType || objType.Equals(typeof(string)))
			return Enumerable.Repeat(Tuple.Create(propertyPath, obj.ToString()), 1);
		else
		{
			// Return empty value for null values
			if (obj == null)
				return Enumerable.Repeat(Tuple.Create(propertyPath, string.Empty), 1);
			else
			{
				// Recursively examine properties; add properties to property path
				return from prop in objType.GetProperties()
					   where prop.CanRead && !prop.GetIndexParameters().Any()
					   let propValue = prop.GetValue(obj, null)
					   let propType = prop.PropertyType
					   from nameValPair in GetProperties(propValue, propType, string.Format("{0}.{1}", propertyPath, prop.Name))
					   select nameValPair;
			}
		}
	}
