     [DataContract]
     public class SomeObject
     {
         [DataMember(Order = 0)]
         [XmlElement()]
         public string item1 { get; set; }
         [DataMember(Order = 1)]
         [XmlElement()]
         public string thing1 { get; set; }
  
         [DataMember(Order = 2)]
         [XmlElement("arrayItem")]
         public List<arrayItem> arrayItems { get; set; }
  
         public SomeObject()
         {
             arrayItems = new List<arrayItem>();
         }
     }
     [DataContract]
     public class arrayItem
     {
         [DataMember]
         [XmlElement()]
         public string foo { get; set; }
     }
