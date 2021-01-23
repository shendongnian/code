    List<DataTable> dts = new List<DataTable>();
    var dt = new DataTable();
    dt.Columns.Add("Test0");
    dt.Rows.Add(1);
    dt.Rows.Add(2);
    dts.Add(dt);
    dt = new DataTable();
    dt.Columns.Add("Test1");
    dt.Rows.Add(2);
    dts.Add(dt);
    dt = new DataTable();
    dt.Columns.Add("Test3", typeof(int));
    dt.Columns.Add("Test4");
    dt.Rows.Add(3, "a");
    dt.Rows.Add(4);
    dt.Rows.Add(5, "a");
    dts.Add(dt);
    dt = new DataTable();
    dt.Columns.Add("Test5", typeof(DateTime));
    dt.Rows.Add(DateTime.Now);
    dts.Add(dt);
    var destination = new DataTable();
    // if you don't have unique column names in the scope of the 
    // DataTable collection, use this
    //for (int i = 0; i < dts.Sum(t => t.Columns.Count); i++)
    //{
    //    destination.Columns.Add(String.Format("column_{0}", i));
    //}
    // if you have unique column names that you want to keep
    // use the following instead, it will also keep the column data type
    foreach (var column in dts
        .SelectMany<DataTable, DataColumn>(t =>
            t.Columns.Cast<DataColumn>()))
    {
        destination.Columns.Add(column.ColumnName, column.DataType);
    }
    List<object> rowItems;
    for (int i = 0; i < dts.Max(t => t.Rows.Count); i++)
    {
        rowItems = new List<object>();
        for (int j = 0; j < dts.Count; j++)
        {
            if (dts[j].Rows.Count > i)
            {
                rowItems.AddRange(dts[j].Rows[i].ItemArray);
            }
            else
            {
                for (int c = 0; c < dts[j].Columns.Count; c++)
                {
                    rowItems.Add(null);
                }
            }
        }
        destination.Rows.Add(rowItems.ToArray());
    }
