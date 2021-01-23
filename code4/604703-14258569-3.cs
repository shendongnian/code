    var table1 = yourDataSet.Tables["Table 1"];
    var table2 = yourDataSet.Tables["Table 2"];
    
    var results = new DataTable();
    
    results.Columns.Add("Name");
    results.Columns.Add("cost", typeof(int));
    
    table1.AsEnumerable().Concat(table2.AsEnumerable())
                    .GroupBy(m => m.Field<string>("Name"))
                    .Select(g => results.Rows.Add(g.Key, g.Sum(x => x.Field<int>("cost"))));
