    public class Class2
    {
        public enum TestEnum
        {
            One = 1,
            Two = 2,
            Three = 3
        }
        public TestEnum[] TestValues { get; set; }
        public static T[] ConvertToEnum<T>(IEnumerable<int> values)
        {
            return values
                .Select(v => (T)Enum.ToObject(typeof(T), v))
                .ToArray();
        }
        public void Test()
        {
            var property = this.GetType().GetProperty("TestValues");
            var value = "1,2,3";
            var convert = this.GetType()
                .GetMethod("ConvertToEnum")
                .MakeGenericMethod(property.PropertyType.GetElementType());
            var intValues = value.Split(',').Select(v => int.Parse(v));
            var result = convert.Invoke(null, new[] { intValues });
            
            property.SetValue(this, result, null);
        }
    }
