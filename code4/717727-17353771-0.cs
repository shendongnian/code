    var id = Request.QueryString["id"].AsInt();
    var accountNum = Request.QueryString["accountnum"];
    
    string[] orderIDs;
    
    // Order IDs are in the form: OrderNum-OrderLine[,...]
    // e.g. orderids=41417-6,36703-1
    
    orderIDs = Request.QueryString["orderids"].Split(',');
    
    var dbContext = new TelecomEntities();
    var assignedLines = dbContext.LineAssignments
        .Where(a => orderIDs
            .Any(on => on.Equals(a.OrderNum + "-" + a.OrderLine))
        .ToList();
