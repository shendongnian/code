    var qry = context
      .MyTable
      .Where(x => x.Code > 5);
        
    switch(orderBy) {
      case "MyField": qry = qry.OrderBy(r => r.MyField); break;
      case "MyField DESC": qry = qry.OrderByDescending(r => r.MyField); break;
    }
    
    // By the way, ToList can infer the generic type if you don't
    // want to state it explicity
    var result = qry.Skip(10).Take(5).ToList();
