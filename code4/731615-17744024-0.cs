    var matched = from table1 in dt1.AsEnumerable()
                          join table2 in dt2.AsEnumerable() on table1.Field<string>("sno") equals table2.Field<string>("sno")
                          where table1.Field<string>("name") == table2.Field<string>("name")
                          select table1;
            if (matched.Count()>0)
            {
                DataTable dtt = matched.CopyToDataTable();
            }
