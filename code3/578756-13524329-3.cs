    [DataContract]
    [Serializable]
    public class SuperObj
    {
      [DataMember]
      public string Foo { get; set; }
      
      [DataMember]
      public string Bar { get; set; }
      
      [DataMember]
      public int Baz { get; set; }
      
      [DataMember]
      public DateTime Qux { get; set; }
    }
