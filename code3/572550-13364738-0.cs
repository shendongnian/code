    [DataContract]
        public class ClassB : InterfaceA
        {
    
            [DataMember(Name = "identifier")]
            public int Id{ get; set; }
    
            [DataMember(Name = "type")]
            public FeedType Type { get; set; }
        }
    var serializer = new DataContractJsonSerializer(ClassB);
    
                var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                var serializedObject = serializer.ReadObject(ms);
