	public static string GetPropertyValue<T>(this T obj, string parameterName)
		{
			PropertyInfo[] property = null;
			Type typ = obj.GetType();
			if (listPropertyInfo.ContainsKey(typ.Name))
			{
				property = listPropertyInfo[typ.Name];
			}
			else
			{
				property = typ.GetProperties();
				listPropertyInfo.TryAdd(typ.Name, property);
			}
			return property.First(p => p.Name == parameterName).GetValue(obj, null).ToString();
		}
