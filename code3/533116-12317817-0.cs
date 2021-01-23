    public class Class2
    {
        public enum TestEnum
        {
            One = 1,
            Two = 2,
            Three = 3
        }
        public TestEnum[] TestValues { get; set; }
        public static T[] ConvertValues<T>(string rawValues)
        {
            return rawValues
                .Split(',')
                .Select(v => (T)Enum.ToObject(typeof(T), int.Parse(v)))
                .ToArray();
        }
        public void Test()
        {
            var property = this.GetType().GetProperty("TestValues");
            var value = "1,2,3";
            var convert = this.GetType()
                .GetMethod("ConvertValues")
                .MakeGenericMethod(property.PropertyType.GetElementType());
            var result = convert.Invoke(null, new[] { value });
            
            property.SetValue(this, result, null);
        }
    }
