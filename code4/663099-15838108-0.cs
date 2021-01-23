    public class Product
    {
      public int OrderID {get;set;}
      public int ProductID {get;set;}
      public string ProductName {get;set;}
      public List<SubProduct> Children {get;set;}  // the magic sauce in this solution
    }
    
    public class SubProduct
    {
      public int SubProductID {get;set;}
      public string SubProductName {get;set;}
    }
