    var users = MyTable.AsEnumerable()
                          .Select(x => new
                          {
                            Col1 = x.Field<string>("Col1"),
                            Col2 = x.Field<string>("Col2")})
                            .ToList();
