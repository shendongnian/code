    private DataTable GetJoinedTable(List<DataTable> dts)
    {
        var dest = new DataTable();
        //will be used if you have non-unique column names
        int counter = 0;
        foreach (var column in dts
            .SelectMany<DataTable, DataColumn>(t =>
                t.Columns.Cast<DataColumn>()))
        {
            dest.Columns.Add(column.ColumnName, column.DataType);
            // if you have non-unique column names use the following instead
            //dest.Columns.Add(String.Format("column_{0}", counter++), 
            //    column.DataType);
        }
        List<object> rowItems;
        for (int i = 0; i < dts.Max(t => t.Rows.Count); i++)
        {
            rowItems = new List<object>();
            for (int j = 0; j < dts.Count; j++)
            {
                if (dts[j].Rows.Count > i)
                {
                    var r = dts[j].Rows[i].ItemArray
                        .Select((v, index) =>
                            (v == null || v == System.DBNull.Value)
                                ? GetDefault(dts[j].Columns[index].DataType) : v);
                    rowItems.AddRange(r);
                }
                else
                {
                    for (int c = 0; c < dts[j].Columns.Count; c++)
                    {
                        rowItems.Add(GetDefault(dts[j].Columns[c].DataType));
                    }
                }
            }
            dest.Rows.Add(rowItems.ToArray());
        }
        return dest;
    }
