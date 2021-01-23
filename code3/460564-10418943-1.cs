    public static string ToEnumString<T>(T type)
    {
    	var enumType = typeof (T);
    	var name = Enum.GetName(enumType, type);
    	var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
    	return enumMemberAttribute.Value;
    }
    public static T ToEnum<T>(string str)
    {
    	var enumType = typeof(T);
    	foreach (var name in Enum.GetNames(enumType))
    	{
    		var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
    		if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
    	}
    	//throw exception or whatever handling you want or
    	return default(T);
    }
