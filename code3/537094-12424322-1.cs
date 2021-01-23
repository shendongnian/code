    public static class MyEnumExtender
    {
        public static string Description(this Enum Value)
        {
            FieldInfo FI = Value.GetType().GetField(Value.ToString());
            IEnumerable<DescriptionAttribute> Attributes = FI.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>();
            return (Attributes.Any()) ? Attributes.First().Description : Value.ToString();
        }
    }
    ....
    MyEnum EnumVar = MyEnum.ValueA;
    string Description = EnumVar.Description();
    
