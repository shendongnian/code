    public class books
    {     
       public int bookNum {get; set; }
       public class book {
             public string name {get; set; }
             public class record {
                 public string borrowDate {get; set; }
                 public string returnDate {get; set; }
             }
             [XmlElement ("record")]
             public record [] records {get; set; }
         }
         [XmlElement ("book")]
         public book [] allBooks {get; set; }
    
         public int book2Num {get; set; }
         public class book2 {
             public string name {get; set; }
             public class record {
                 public string borrowDate {get; set; }
                 public string returnDate {get; set; }
             }
             [XmlElement ("record")]
             public record [] records {get; set; }
         }
         [XmlElement ("book2")]
         public book2 [] allBook2 {get; set; }
    }`
