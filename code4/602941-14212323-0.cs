    You can try like the below one.Here location is common entity between two tables.
    
    var results = t1.AsEnumerable().Join(t2.AsEnumerable(),
                    a => a.Field<String>("Location"),
                    b => b.Field<String>("Location"),
                    (a, b) =>
                    {
                        DataRow row = table.NewRow();
                        row.ItemArray = a.ItemArray.Concat(b.ItemArray).ToArray();
                        table.Rows.Add(row);
                        return row;
                    });
