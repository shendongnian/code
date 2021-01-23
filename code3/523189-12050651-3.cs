    var clients = clientList.ToLookup(x => x.ClientNo);
    var matters = matterList.ToLookup(x => x.ClientNo);
    var stocks = stockList.ToLookup(x => x.Sedol);
    
    var reportList = new List<GeneralHoldingsReport>(dHoldList.Count);
    
    foreach(var holding in dHoldList)
    {
        foreach(var item in from client in clients[holding.ClientNo].DefaultIfEmpty()
                            from matter in matters[holding.ClientNo].DefaultIfEmpty()
                            from stock in stocks[holding.Sedol].DefaultIfEmpty()
                            select new { Client = client, Matter = matter, Stock = stock })
        {
            reportList.Add(new GeneralHoldingsReport()     
                           {     
                               ClientNo = holding.ClientNo,     
                               Depot = holding.Depot,     
                               HoldingSedol = holding.Sedol,     
                               Value = holding.ValueOfStock,     
                               NoOfUnits = holding.QuantityHeld,     
                               ClientName = (item.Client == null ? null :
                                             item.Client.ClientName),     
                               CountryOfResidence = (item.Client == null ? null : 
                                                     item.Client.CountryOfResidence),     
                               BG = (item.Client == null ? null : 
                                     item.Client.BusinessGetter),     
                               ClientStockValue = (item.Matter == null ? 0 : 
                                                   item.Matter.FullValueOfPortfolio),     
                               StockName = (item.Stock == null ? null : 
                                            item.Stock.R1.Trim() + " " 
                                            + item.Stock.R2.Trim())     
                           });
        }
    } 
