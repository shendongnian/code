    public enum Enum
    {
    	[Display(Name = "What a weird name!")]
    	ToString,
    
    	Equals
    }
    
    public static class EnumHelpers
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
    
            return enumType
                    .GetMember(enumValue.ToString())
    				.Where(x => x.MemberType == MemberTypes.Field && ((FieldInfo)x).FieldType == enumType)
    				.First()
    				.GetCustomAttribute<DisplayAttribute>()?.Name ?? enumValue.ToString();
    	}
    }
    void Main()
    {
    	Assert.Equals("What a weird name!", Enum.ToString.GetDisplayName());
        Assert.Equals("Equals", Enum.Equals.GetDisplayName());
    }
