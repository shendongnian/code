    var clients = clientList.ToDictionary(x => x.ClientNo);
    var matters = matterList.ToDictionary(x => x.ClientNo);
    var stocks = stockList.ToDictionary(x => x.Sedol);
    
    var reportList = new List<GeneralHoldingsReport>(dHoldList.Count);
    Client client;
    Matter matter;
    Stock stock;    
    foreach(var holding in dHoldList)
    {
        if(!clients.TryGetValue(holding.ClientNo, out client))
            client = null;
        if(!matters.TryGetValue(holding.ClientNo, out matter))
            matter = null;
        if(!stocks.TryGetValue(holding.Sedol, out stock))
            stock = null;
        reportList.Add(new GeneralHoldingsReport()     
                       {     
                           ClientNo = holding.ClientNo,     
                           Depot = holding.Depot,     
                           HoldingSedol = holding.Sedol,     
                           Value = holding.ValueOfStock,     
                           NoOfUnits = holding.QuantityHeld,     
                           ClientName = (client == null ? null :
                                         client.ClientName),     
                           CountryOfResidence = (client == null ? null : 
                                                 client.CountryOfResidence),     
                           BG = (client == null ? null : 
                                 client.BusinessGetter),     
                           ClientStockValue = (matter == null ? 0 : 
                                               matter.FullValueOfPortfolio),     
                           StockName = (stock == null ? null : 
                                        stock.R1.Trim() + " " 
                                        + stock.R2.Trim())     
                       });
    } 
