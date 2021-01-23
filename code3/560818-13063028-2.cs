    var result = table.AsEnumerable()
                .GroupBy(r => r.Field<string>("Version"))
                .Select(g =>
                    {
                        var row = table.NewRow();
                        row.ItemArray = new object[]
                            {
                                g.Key, 
                                g.Sum(r => r.Field<int>("Value"))
                            };
                        return row;
                    }).CopyToDataTable();
