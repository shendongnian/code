    var mergeTable = dt1.AsEnumerable()
         .Concat(dt2.AsEnumerable())
         .Concat(dt3.AsEnumerable())
         .GroupBy(row => new { 
                            Test1 = row.Field<string>("Test1")
                            Test2 = row.Field<string>("Test2") 
                            Test3 = row.Field<string>("Test3") 
                            })
         
         .Select(g => g.First())
         .CopyToDataTable();
