    table = table.AsEnumerable()
                 .GroupBy(r => new
                 { 
                     ItemName = r.Field<string>("ItemName"),
                     ItemNo   = r.Field<int>("ItemNo") 
                 })
                 .OrderBy(g => g.Key.ItemNo)
                 .SelectMany(g => g.OrderBy(r => r.Field<double>("ItemValue")))
                 .CopyToDataTable();
