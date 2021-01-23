    var columns = dataSet.Tables
                         .Cast<DataTable>()
                         .SelectMany(t=>t.Columns
                                         .Cast<DataColumn>()
                                         .Select(c=> new {
                                                          t.TableName, 
                                                          c.ColumnName
                                                         }
                                                )
                                     );
