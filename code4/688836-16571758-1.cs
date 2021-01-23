    public class Invoice
    {
      public int Id { get; set; }
      public int OwnerId { get; set; }
      public List<PurchaseInfo> Purchases { get; set; }
    }
