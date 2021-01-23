    List<Dictionary<string, string>> myList = new List<Dictionary<string, string>>()
                                                           { new Dictionary<string,string>() { { "ABC", "This" },
                                                                                               { "DEF", "is" },
                                                                                               { "GHI", "radio" },
                                                                                               { "JKL", "clash" } } };
    
    DataTable dt = new DataTable();
    
    // Add columns first
    dt.Columns.AddRange( myList.First ()
                               .Select (kvp => new DataColumn() { ColumnName = kvp.Key, DataType = System.Type.GetType("System.String")} )
                               .AsEnumerable()
                               .ToArray()
                               );
    
    // Now add the rows
    myList.SelectMany (Dict => Dict.Select (kvp => new {
                                                        Row = dt.NewRow(),
                                                        Kvp = kvp
                                                        }))
          .ToList()
          .ForEach( rowItem => {
                                  rowItem.Row[rowItem.Kvp.Key] = rowItem.Kvp.Value;
                                  dt.Rows.Add( rowItem.Row );
                               }
                 );
    dt.Dump();
