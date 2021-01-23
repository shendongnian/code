    static void Main(string[] args)
    {
        var serializeMe = new Foo() { Id = new ComponentIdentifier() };
        var xml = Serialize(serializeMe);
        Console.WriteLine(xml);
        Console.ReadKey();
    }
    [DataContract]
    public class Foo
    {
        [DataMember(Name = "Id")]
        private string IdForSerialization
        {
            get { return Id.identifier.ToString(); }
            set { Id = new ComponentIdentifier() {identifier = int.Parse(value)}; }
        }
        public ComponentIdentifier Id { get; set; }
    }
    [DataContract]
    public struct ComponentIdentifier
    {
        [DataMember]
        public long identifier;
    }
    // thanks to http://stackoverflow.com/questions/5010191/using-datacontractserializer-to-serialize-but-cant-deserialize-back
    public static string Serialize(object obj)
    {        
        using (MemoryStream memoryStream = new MemoryStream())
        using (StreamReader reader = new StreamReader(memoryStream))
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            serializer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            return reader.ReadToEnd();
        }
    }
