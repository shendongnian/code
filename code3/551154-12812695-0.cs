    var result =  DTTable1.AsEnumerable()
                       .Where(row => !DTTable2.AsEnumerable()
                                             .Select(r => r.Field<int>("ItemID"))
                                             .Any(x => x == row.Field<int>("ItemID"))
                      ).CopyToDataTable();
          
