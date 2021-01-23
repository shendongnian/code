    public static string ToEnumString<T>(T type)
    {
    	var enumType = typeof (T);
    	var name = Enum.GetName(enumType, type);
    	var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
    	return enumMemberAttribute.Value;
    }
