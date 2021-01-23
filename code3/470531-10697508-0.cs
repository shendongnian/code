    [TypePath(@"C:\")]
    public class classA
    {
    }
    [TypePath(@"D:\")]
    public class classB
    {
    }
    public class ReadPath<T>
    {        
        public static List<T> ReadType()
        {
            var attrib = (TypePathAttribute)Attribute.GetCustomAttribute(
                  typeof(T), typeof(TypePathAttribute));
            var path = attrib.Path;
            ...
        }        
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct
        | AttributeTargets.Interface | AttributeTargets.Enum,
        AllowMultiple = false, Inherited = false)]
    public class TypePathAttribute : Attribute
    {
        public string Path { get; private set; }
        public TypePathAttribute(string path) { Path = path; }
    }
