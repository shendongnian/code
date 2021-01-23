		public static object SetStringPropertiesOnly(object obj)
		{
			var properties = obj.GetType().GetProperties();
			var strings = properties.Where(p=>p.PropertyType == typeof(string);
			foreach(PropertyInfo property in strings)
			{
				property.SetValue(obj, "Value");
			}
			return obj;
		}
