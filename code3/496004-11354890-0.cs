    var collection = database.GetCollection("log");
    var query = Query.And(
        Query.GT("datetime", new DateTime(2012, 7, 5, 19, 55, 18, 475, DateTimeKind.Utc)),
        Query.LT("datetime", new DateTime(2012, 7, 5, 20, 55, 18, 475, DateTimeKind.Utc))
    );
    var result = collection.Distinct("cs_uri_stem", query);
    foreach (var distinctValue in result)
    {
        // process distinctValue
    }
