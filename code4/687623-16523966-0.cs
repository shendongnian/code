	public static string GetProperties(object obj)
    {
		var t = obj.GetType();
        var properties = t.GetProperties();
		var s = "";
        foreach (PropertyInfo property in properties)
        {
			object propValue = property.GetValue(obj, new object[0]);
			string propertyToString;
			if (t.GetMethod("ToString").DeclaringType != typeof(object))
				propertyToString = propValue.ToString();
			else if (typeof(IConvertible).IsAssignableFrom(property.PropertyType))
				propertyToString = Convert.ToString(propValue);
			else
				propertyToString = GetProperties(propValue);
				
            s += string.Format("'{0}' = '{1}'", property.Name, propertyToString);
        }
		return s;
    }
