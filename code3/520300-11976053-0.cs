    [DataContract(Name="MyEmail", Namespace="http://contoso.org/soa/datacontracts")]
    public class Email
    {
      [DataMember(Name="ToField", IsRequired=true, Order=0]
      public string To { get; set; }
    
      [DataMember(Name="FromField", IsRequired=false, Order=1]
      public string From { get; set; }
    
      [DataMember(Name="MessageField", IsRequired=true, Order=2]
      public string Message { get; set; }
    
      [DataMember(Name="SubjectField", IsRequired=false, Order=3]
      public string Subject { get; set; }
     
      public string OtherProp1 {get; set;}
      public string OtherProp2 {get; set;}
      public string OtherProp3 {get; set;}    
    }
