    // NOTE: Not meant for production!
    [DataContract]
    public class GenericWcfPayload
    {
       [DataMember]
       public byte[] Payload {get; set;}
    
       [DataMember]
       public string TypeName {get; set;}
    }
