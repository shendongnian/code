    static void Main(string[] args)
    {
        var serializeMe = new Foo() { Id = new ComponentIdentifier() };
        var xml = Serialize(serializeMe, new ComponentIdentifierSurrogate());
        Console.WriteLine(xml);
        Console.ReadKey();
    }
    [DataContract]
    [DataContract]
    public class Foo
    {
        [DataMember]
        public ComponentIdentifier Id { get; set; }
    }
    [DataContract]
    public struct ComponentIdentifier
    {
        [DataMember]
        public long identifier;
    }
    class ComponentIdentifierSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(ComponentIdentifier))
                return typeof(string);
            return type;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is ComponentIdentifier)
                return ((ComponentIdentifier)obj).identifier.ToString();
            return obj;
        }
        ...
    }
    public static string Serialize(object obj, IDataContractSurrogate surrogate)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        using (StreamReader reader = new StreamReader(memoryStream))
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType(), null, int.MaxValue, false, false, new ComponentIdentifierSurrogate());
            serializer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            return reader.ReadToEnd();
        }
    }
