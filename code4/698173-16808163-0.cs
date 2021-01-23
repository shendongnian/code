    var keyColRows = dt1.AsEnumerable()
        .Select(r => r.Field<int>("KeyColumn")
        .Except(dt2.AsEnumerable().Select(r2 => r2.Field<int>("KeyColumn"));
    foreach(int inTable2Missing)
        Console.WriteLine(inTable2Missing);
