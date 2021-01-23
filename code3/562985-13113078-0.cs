    int storeID = -1;
    StringBuilder builder = new StringBuilder();
    
    foreach (var item in skuStoreStockLevel.OrderBy(x => x.Item1))
    {
        builder.AppendFormat("{0}{1},{2},{3}", sSeparator, item.Item1, item.Item2, item.Item3);
        if (item.Item1 != storeID)
        {
            // some code to process the string before moving on
            storeID = item.Item1;
        }       
    }
