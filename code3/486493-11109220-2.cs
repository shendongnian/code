    [OperationContract]
    public Whatever  MyMethod(DataPacket rawJSON)
    { 
         ....
    }
    [DataContract]
    public class DataPacket
    {
      [DataMember]
      public JsonDictionary Registration { get; set; }
    }
