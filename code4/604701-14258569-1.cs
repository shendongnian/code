    var table1 = yourDataSet.Tables["Table 1"];
    var table2 = yourDataSet.Tables["Table 2"];
    
    var results = table1.AsEnumerable().Select(t1 => new {
                      name = t1.Field<string>("Name"),
                      cost = t1.Field<int>("cost")
                  })
                  .Concat(
    
                  table2.AsEnumerable().Select(t2 => new {
                      name = t2.Field<string>("Name"),
                      cost = t2.Field<int>("cost")
                  })
                  )
                  .GroupBy(m => m.name)
                  .Select(g => new {
                     name = g.Key,
                     cost = g.Sum(x => x.cost)
                  });
