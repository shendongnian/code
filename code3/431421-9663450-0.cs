    [DataContract]
    public class Person : BaseObject
    {
        [DataMember]
        public string Age { get; set; }
    
        [DataMember]
        public string Name { get; set; }
    }
    
    [DataContract]
    [KnownType(typeof(Person))]
    public class BaseObject
    {
    }
    static string Serialize<T>(T item)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
    
        string result;
        using (var ms = new MemoryStream())
        {
            serializer.WriteObject(ms, item);
            result = Encoding.Default.GetString(ms.ToArray());
        };
        return result;
    }
