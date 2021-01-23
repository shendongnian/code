    public class PurchaseInfo
    {
      public int Id { get; set; }
      public int Quantity { get; set; }
      public int InvoiceId { get; set; }
      public Invoice Invoice { get; set; }
      public int Item {get;set;}
      public List<Product> Products { get; set; }
    }
