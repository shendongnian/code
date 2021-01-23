    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    
        public static String GetDescription(this Enum value)
        {
            var description = GetAttribute<DescriptionAttribute>(value);
            return description != null ? description.Description : null;
        }
    }
    
    enum MyEnum
    {
        [Description("abc")] Name1,
        [Description("xyz")] Name2,
    }
    
    var value = MyEnum.Name1;
    if (value.GetDescription() == "abc")
    {
        // do stuff...
    }
