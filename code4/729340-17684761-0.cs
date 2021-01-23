    public class SomeClass
    {
        public IDictionary<Type, Action<object>> RegistryVoid { get; set; }
        public IDictionary<Type, Func<object, int>> RegistryInt { get; set; }
        public void SomeDlsMethod()
        {
            ...
            // Example when you need to convert your DSL data object to int:
            int value = RegistryInt[someDslObject.GetType()](someDslObject);
        }
    }
