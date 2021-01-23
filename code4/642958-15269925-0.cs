    List<int> MyList = Table1.AsEnumerable()
                             .GroupBy(row => new {
                                                 Col1 = row.Field<int>("Col1"),
                                                 Col2 = row.Field<string>("Col2")
                                             })
                             .Where(g => g.Count() > 1)
                             .Select(g => g.Key.Col1)
                             .ToList();
