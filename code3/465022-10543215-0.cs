    var query = table1.AsEnumerable()
        .GroupBy(row => row.Field<int>("ID"))
        .Select(grp =>
                {
                    dynamic result = new ExpandoObject();
                    var dict = result as IDictionary<string, object>;
                    result.ID = grp.Key;
                    foreach (DataRow row in grp)
                    {
                        foreach (DataColumn column in table1.Columns)
                        {
                            string columnName = column.ColumnName;
                            if (columnName.Equals("ID"))
                                continue;
                            if (columnName.Equals("Name"))
                            {
                                dict[columnName] = row[columnName];
                                continue;
                            }
                            //else
                            if (!dict.Keys.Contains(columnName))
                                dict[columnName] = row[columnName];
                            else
                            {
                                if (row[columnName] is System.DBNull)
                                    continue;
                                if (dict[columnName] is System.DBNull)
                                {
                                    dict[columnName] = row[columnName];
                                    continue;
                                }
                                //else
                                dict[columnName] = ((decimal)dict[columnName] + (decimal)row[columnName]);
                            }
                        }
                    }
                    return result;
                });
