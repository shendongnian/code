    public interface ITestInterface
    {
        string Guid { get; set; }
    }
    
    public class TestClassThatImplementsTestInterface1 : ITestInterface
    {
        public string Guid { get; set; }
        public string Something1 { get; set; }
    }
    
    public class TestClassThatImplementsTestInterface2 : ITestInterface
    {
        public string Guid { get; set; }
        public string Something2 { get; set; }
    }
    
    public class ClassToSerializeViaJson
    {
        public ClassToSerializeViaJson()
        {
            this.CollectionToSerialize = new List<ITestInterface>();
        }
        public List<ITestInterface> CollectionToSerialize { get; set; }
    }
    
    public class TypeNameSerializationBinder : SerializationBinder
    {
        public string TypeFormat { get; private set; }
    
        public TypeNameSerializationBinder(string typeFormat)
        {
            TypeFormat = typeFormat;
        }
    
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    
        public override Type BindToType(string assemblyName, string typeName)
        {
            var resolvedTypeName = string.Format(TypeFormat, typeName);
            return Type.GetType(resolvedTypeName, true);
        }
    }
    
    class Program
    {
        static void Main()
        {
            var binder = new TypeNameSerializationBinder("ConsoleApplication.{0}, ConsoleApplication");
            var toserialize = new ClassToSerializeViaJson();
            
            toserialize.CollectionToSerialize.Add(
                new TestClassThatImplementsTestInterface1()
                {
                    Guid = Guid.NewGuid().ToString(), Something1 = "Some1"
                });
            toserialize.CollectionToSerialize.Add(
                new TestClassThatImplementsTestInterface2()
                {
                    Guid = Guid.NewGuid().ToString(), Something2 = "Some2"
                });
    
            string json = JsonConvert.SerializeObject(toserialize, Formatting.Indented, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Binder = binder
                });
            var obj = JsonConvert.DeserializeObject<ClassToSerializeViaJson>(json, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Binder = binder 
                });
            
            Console.ReadLine();
        }
    }
