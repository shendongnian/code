            var tblDataValues = DtSet.Tables["tblData"].AsEnumerable()
                                    .Select(row => new
                                    {
                                        name_1 = "1",
                                        name_2 = "I",
                                        name_3 = row.Field<string>("EorD"),
                                        name_4 = row.Field<string>("InvNo")
                                    })
                                    .Distinct();;
            var tblCostValues = DtSet.Tables["tblCost"].AsEnumerable()
                                    .Select(row => new
                                    {
                                        InvNo = row.Field<string>("InvNo"),
                                        Amount = row.Field<int>("Amount"),
                                    }
                );
            var joinedValue = tblDataValues.Join(tblCostValues, v => v.name_4, c => c.InvNo, (c, v) => new { c, v })
                    .GroupBy(k => k.v, c => c.c)
                    .Select(g => new
                    {
                        g.Key.name_1,
                        g.Key.name_2,
                        g.Key.name_3,
                        g.Key.name_4,
                        name_5 = g.Aggregate(0, (s, c) => s + c.Amount)
                    });
