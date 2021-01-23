    var summedValues = from table in dt.AsEnumerable()
                       group table by table.Field<string>("Name")
                       into groupedTable
                       select new
                                 {
                                    Name = groupedTable.Key,
                                    Total = groupedTable.Sum(x => x.Field<int>("Total"))
                                 }; 
