	public static string GetDisplayAttributeFrom(this Enum enumValue, Type enumType)
	{
		return enumType.GetMember(enumValue.ToString())
					   .First()
					   .GetCustomAttribute<DisplayAttribute>()
					   .Name;
	}
