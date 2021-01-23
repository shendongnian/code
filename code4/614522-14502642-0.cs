    var checkDate = DateTime.Now.AddMonths(-12);
    
    var resultList = db.Work_Stations
      .Distinct()
      .Select(ws => new {Ws = ws, Li = ws.Invoices.OrderBy(i => i.Invoice_Date).LastOrDefault()})
      .Where(item => item.Li != null && Li.Invoice_Date < checkDate)
      .Select(item => item.Ws)
      .ToList();
