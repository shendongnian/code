    [DataContract]
    public class MyClass
    {
        [DataMember]
        public string AMember{get;set;}
    
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            // called after deserializing instance of MyClass
        }
    }
