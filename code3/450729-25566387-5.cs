    [DataContract]
    public class Computer
    {
      // included in JSON
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public decimal SalePrice { get; set; }
     
      // ignored
      public string Manufacture { get; set; }
      public int StockCount { get; set; }
      public decimal WholeSalePrice { get; set; }
      public DateTime NextShipmentDate { get; set; }
    }
