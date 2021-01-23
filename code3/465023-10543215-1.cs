    var query = table1.AsEnumerable()
        .GroupBy(row => new
                        {
                            ID = row.Field<int>("ID"),
                            Name = row.Field<string>("Name")
                        })
        .Select(grp =>
        {
            dynamic result = new ExpandoObject();
            var dict = result as IDictionary<string, object>;
            dict["ID"] = grp.Key.ID;
            dict["Name"] = grp.Key.Name;
            foreach (DataRow row in grp)
            {
                foreach (DataColumn column in table1.Columns)
                {
                    string columnName = column.ColumnName;
                    if (columnName.Equals("ID") || columnName.Equals("Name"))
                        continue;
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
