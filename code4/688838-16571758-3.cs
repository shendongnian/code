    public class Product
    {
      public int Sku { get; set; }
      public int ProductLineId { get; set; }
      public int ItemCount { get; set; }
      public List<PurchaseInfo> PurchaseInfos { get; set; }
    }
