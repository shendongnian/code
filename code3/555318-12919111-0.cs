    private class StockValue
    {
      public Double TotalQtyHeld { get; set; }
      public Double TotalValueOfStock { get; set; }
      public DateTime Date { get; set; }
    }
    
    private class Stocks: ExcelReport
    {
      public String StockCode { get; set; }
      public IList<StockValue> Values {get;set;}
    }
