		public static void SetStringProperties(this object obj, string value)
		{
			var properties = obj.GetType().GetProperties();
			var strings = properties.Where(p=>p.PropertyType == typeof(string);
			foreach(PropertyInfo property in strings)
			{
				property.SetValue(obj, value);
			}
			return obj;
		}
