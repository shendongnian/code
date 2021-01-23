    List<Data> myOrders = GetList();
    
    IEnumerable<Data> groupingQuery = myOrders
      .GroupBy(data => new { data.itemName, data.partName } )
      .Select(g => new Data()
      {
        itemName = g.Key.itemName,
        partName = g.Key.partName,
        itemQuantity = g.Sum(x => x.itemQuantity),
        partQuantity = g.Sum(x => x.partQuantity)
      })
      .OrderBy(data => data.itemName)
      .ThenBy(data => data.partName);
