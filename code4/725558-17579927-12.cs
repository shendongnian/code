    public class Customer
    {
      public int CustomerID { get; set; }
      public string Name { get; set; }
      public virtual List<Order> Orders { get; set; }
    }
    public class Order
    {
      public int OrderID { get; set; }
      public DateTime OrderDate { get; set; }
      public decimal TotalPurchaseAmount { get; set; }
      public string Comments { get; set; }
      public bool Shipped { get; set; }
      public virtual Customer Customer { get; set; }
    }
