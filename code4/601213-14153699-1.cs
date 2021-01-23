    var mysales = ds.Tables[0].AsEnumerable()
                              .Select(r => new {
                                      column2 = r.Field<double>("sales")
                                     });
    List<double> sales = mysales.ToList();
