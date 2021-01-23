    [TestFixture]
    public sealed class ForTest
    {
        [Test]
        public void Test()
        {
            var values = typeof(Levels).ToValues();
            values.ForEach(Console.WriteLine);
        }
    }
    public static class TypeExtensions
    {
        public static List<string> ToValues(this Type value)
        {
            var result = new List<string>();
            var values = ToConcreteValues(value);
            foreach (dynamic item in values)
            {
                Description attribute = GetAttribute<Description>(item);
                result.Add(attribute.Description);
            }
            return result;
        }
        private static dynamic ToConcreteValues(Type enumType)
        {
            Array values = Enum.GetValues(enumType);
            Type list = typeof (List<>);
            Type resultType = list.MakeGenericType(enumType);
            dynamic result = Activator.CreateInstance(resultType);
            foreach (object value in values)
            {
                dynamic concreteValue = Enum.Parse(enumType, value.ToString());
                result.Add(concreteValue);
            }
            return result;
        }
        private static TAttribute GetAttribute<TAttribute>(dynamic value)
            where TAttribute : Attribute
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(Enum.GetName(type, value));
            return (TAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof (TAttribute));
        }
    }
    public enum Levels
    {
        [Description("Low level")]LOW,
        [Description("Normal level")] NORMAL,
        [Description("High level")] HIGH
    }
