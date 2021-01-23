    var result = row.Table
                    .Columns
                    .Cast<DataColumn>()
                    .Where(column => column.ColumnName.StartsWith("FK"))
                    .ToDictionary(column => column.ColumnName,
                                  column => Convert.ToString(row[column]));
