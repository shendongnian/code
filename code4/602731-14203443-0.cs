    public class OrderDetailedModel
    {
    
      [Key, ForeignKey("Order")]
      public int OrderID { get; set; }
    
      //some properties
    
      public virtual OrderModel Order { get; set; }
    
    }
