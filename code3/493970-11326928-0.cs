	public static class ReflectionHelper
	{
		public static void IterateProps(Object obj, string baseProperty, ref Dictionary<string,object> properties )
		{
			if (obj != null)
			{
				var baseType = obj.GetType();
				var props = baseType.GetProperties();
				foreach (var property in props)
				{
					var name = property.Name;
					var propType = property.PropertyType;
					if (propType.IsClass && propType.Name != "String")
					{
						IterateProps(property.GetValue(obj, null), baseProperty + "." + property.Name, ref properties);
					}
					else
					{
						properties.Add(baseProperty + "." + name, property.GetValue(obj, null));
					}
				}
			}
		}
	}
