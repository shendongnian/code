    using System.Runtime.Serialization;
    [DataContract]
    public class Race {
      [DataMember]
      public String Name { get; set; }
      [DataMember]
      public String Location { get; set; }
      [DataMember]
      public DateTime ScheduledAt { get; set; }
      [DataMember]
      public String URL { get; set; }
    }
