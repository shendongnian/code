	public static IDictionary<string, string> GetProperties<T>(this T obj)
	{
		Type t = obj.GetType();
		var properties = from prop in t.GetProperties()
						 where prop.CanRead
						 let propValue = prop.GetValue(obj, null)
						 select new { Name = prop.Name, Value = (propValue == null ? string.Empty : propValue.ToString()) };
		return properties.ToDictionary(prop => prop.Name, prop => prop.Value);
	}
