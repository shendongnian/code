    var pivotTable = table.AsEnumerable()
                          .Select(r => new {
                              Object = r.Field<string>("Object"),
                              Attribute = r.Field<string>("Attribute"),
                              Value = r.Field<object>("Value")
                          })
                          .ToPivotTable(r => r.Attribute, 
                                        r => r.Object, 
                                        rows => rows.First().Value);
