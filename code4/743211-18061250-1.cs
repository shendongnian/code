    var fields = new List<string>() { "Territory", "Bank Name"};
    var qfields = string.Join(", ", fields.Select(x => "it[\"" + x + "\"] as " + x));
    
    var q = dt
        .AsEnumerable()
        .AsQueryable()
        .GroupBy("new(" + qfields + ")", "it")
        .Select("new (it as Data)");
    foreach (dynamic d in q)
    {
        foreach (var row in d.Data)
        {
           // Do your work here, using d.Territory
        }  
    }
