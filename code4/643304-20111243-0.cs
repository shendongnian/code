    public class Product
    {
    
      [Range(5, 50)]
      public int ReorderLevel { get; set; }
    
      [Range(typeof(Decimal),"5", "5000")]
      public decimal ListPrice { get; set; }
    
    }
