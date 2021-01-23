    [DataContract]
    public class Data
    {
         [DataMember]
         public string Required { get; set; }
         
         [DataMember(IsRequired=false)]
         public string? NotRequired { get; set; }
    }
