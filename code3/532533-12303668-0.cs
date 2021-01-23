    public class Report {
       public int Id {get;set;}
       public int Lot {get;set;}
       public Datetime CreatedDate {get;set;}
       public virtual Category Category {get;set;} //Navigation property
    }
