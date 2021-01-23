    [DataContract]
    public class SerializationRequest
    {
         // ...
    
         [DataMember]
         public string TypeName {get;set;}
    }
    // ...
    var type = Type.GetType(response.TypeName);
    var serializer = new DataContractJsonSerializer(type);
