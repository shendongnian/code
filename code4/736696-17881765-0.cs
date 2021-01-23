    INV_STOCKs.GroupBy(x=>x.STOCK_DATE).ForEach(group=>
    {
       var g = group.OrderBy(x.ID);
       Print(g.First().STOCK_DATE); //Date
       Print(g.First().STOCK_QTY); //Opening stock
       Print(g.Last().STOCK_QTY); //Closing stock
    });
