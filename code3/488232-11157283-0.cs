    public static object GetDefaultPropertyValue(Type type, string propertyName)
	{
			if (type.GetConstructor(new Type[] { }) == null)
				throw new Exception(type + " doesn't have a default constructor, so there is no default instance to get a default property value from.");
			var obj = Activator.CreateInstance(type);
			return type.GetProperty(propertyName).GetValue(obj, new object[] { });
	}
