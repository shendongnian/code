    var beginDate = date.Date;          // e.g. 7/24/2013 00:00:00
    var endDate = beginDate.AddDays(1); // e.g. 7/25/2013 00:00:00
    var query = Query.And(Query<Log>.GTE(l => l.Date, beginDate), // including
                          Query<Log>.LT(l => l.Date, endDate)); // not including
    var result = _logCollection.FindAs<Log>(query);
