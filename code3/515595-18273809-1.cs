    [DataContract]
    public class MyClass {
      [DataMember]
      public int Id { get; set;} // Serialized
      [DataMember]
      public string Name { get; set; } // Serialized
      public string DontExposeMe { get; set; } // Will not be serialized
    }
