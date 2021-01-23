    var resultSetInMemory = new List<decimal>();
    if(somethink) {
     resultSetInMemory = databaseContext.Foo
                                        .Where(f=>f.Bar > 5)
                                        .Select(f.key)
                                        .ToList();
    }
    if(somethingElse) {
     resultSetInMemory = databaseContext.Foo
                                       .Where(f=>f.Bar > 15)
                                       .Select(f.key)
                                       .ToList();
    }
    
    var json = new JavaScriptSerializer.Serialize(new { fooKeys = resultSetInMemory });
