    public enum TestEnum
    {
        [EnumString("Value One")]
        Value1,
    
        [EnumString("Value Two")]
        Value2,
    
        [EnumString("Value Three")]
        Value3
    }
    
    EnumTest test = EnumTest.Value1;
    Console.Write(test.ToStringEx());
    The code to accomplish this is pretty simple:
    
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumStringAttribute : Attribute
    {
        private string enumString;
    
        public EnumStringAttribute(string EnumString)
        {
            enumString = EnumString;
        }
    
        public override string ToString()
        {
            return enumString;
        }
    }
    
    public static class ExtensionMethods
    {
        public static string ToStringEx(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            FieldInfo field = type.GetField(enumeration.ToString());
            var enumString =
                (from attribute in field.GetCustomAttributes(true)
                 where attribute is EnumStringAttribute
                 select attribute).FirstOrDefault();
    
            if (enumString != null)
                return enumString.ToString();
    
            // otherwise...
            return enumeration.ToString();
        }
    }
    
    [TestMethod()]
    public void ToStringTest()
    {
        Assert.AreEqual("Value One", TestEnum.Value1.ToStringEx());
        Assert.AreEqual("Value Two", TestEnum.Value2.ToStringEx());
        Assert.AreEqual("Value Three", TestEnum.Value3.ToStringEx());
    }
