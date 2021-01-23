    public class Contract { 
      public int? ContractID { get; set; } 
      [XmlAttribute(AttributeName= "PostingID")] 
      public string PostingID { get; set; } 
      public System.Nullable<EntryTypeOptions> EntryType { get; set; } 
    }
