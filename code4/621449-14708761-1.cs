    public class Order
    {
      public int Id {get; set;}
      public virtual Quotation Quotation { get; set; }
      // other properties
    }
    
    public class Quotation
    {
      public int Id {get; set;}
      public virtual Order Order { get; set; }
      // other properties
    }
