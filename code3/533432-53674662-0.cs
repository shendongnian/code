    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string t) where T: struct 
        {
            return (T)Enum.Parse(typeof (T), t);
        }
    }
    ...
    var EnumValue = "StringValue".ParseEnum<MyEnum>();
