    class StockStore
    {
       public int OpeningStock;
       public int ClosingStock;
       public DateTime Date;
    }
    var list = new List<StockStore>();
  
    INV_STOCKs.GroupBy(x=>x.STOCK_DATE).ForEach(group=>
    {
       var g = group.OrderBy(x.ID);
       list.Add(new StockStore 
       {
           OpeningStock = g.First().STOCK_QTY,
           ClosingStock = g.Last().STOCK_QTY,
           Date = g.First().STOCK_DATE
       }); 
    });
