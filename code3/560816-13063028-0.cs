    var result = table.AsEnumerable()
                .GroupBy(r => r.Field<String>("Version"))
                .Select(g =>
                    {
                        var row = table.NewRow();
                        row.ItemArray = new object[] {g.Key, g.Count()};
                        return row;
                    }).CopyToDataTable();
