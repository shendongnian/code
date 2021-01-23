    [Table("webnews_in")]
    public class WEBNews_in : AbsNews {
    
       private DateTime _inDateTimeAdded = DateTime.MinValue;
    
       public string InDateTimeAdded {
           get {
               return Format(_inDateTimeAdded, " dd/MM/yyyy hh:mm:ss tt");
           }
           set {
               _inDateTimeAdded = DateTime.Parse(value);
           }
       }
    
       private DateTime _inDateTimeUpdated = DateTime.MinValue;
    
       public string InDateTimeUpdated {
           get {
               return Format(_inDateTimeUpdated, " dd/MM/yyyy hh:mm:ss tt");
           }
           set {
               _inDateTimeUpdated = DateTime.Parse(value);
           }
       }
    }
