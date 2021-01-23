    public class Order
    {
           public int Id {get; set;}
           public virtual Quotation Quotation { get; set; }
    }
    
    public class Quotation
    {
         [Key, ForeignKey(nameof(Order))]
         public int Id {get; set;}
         public virtual Order Order { get; set; }
    }
