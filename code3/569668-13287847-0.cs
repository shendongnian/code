    public static void SetPropertyValue<T>(this T obj, string parameterName, object value)
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
			if (value == DBNull.Value)
			{
				value = null;
			}
			property.First(p => p.Name == parameterName).SetValue(obj,value, null);
		}
