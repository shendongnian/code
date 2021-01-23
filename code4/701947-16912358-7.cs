    #region table collection initialization
    List<DataTable> dts = new List<DataTable>();
    var dt = new DataTable();
    dt.Columns.Add("Test0", typeof(string));
    dt.Rows.Add(1);
    dt.Rows.Add(2);
    dts.Add(dt);
    dt = new DataTable();
    dt.Columns.Add("Test1", typeof(int));
    dt.Rows.Add(2);
    dts.Add(dt);
    dt = new DataTable();
    dt.Columns.Add("Test3", typeof(int));
    dt.Columns.Add("Test4");
    dt.Columns.Add("Test5", typeof(int));
    dt.Rows.Add(3, "a", 1);
    dt.Rows.Add(4);
    dt.Rows.Add(5, "a");
    dt.Rows.Add(null, "a");
    dts.Add(dt);
    dt = new DataTable();
    dt.Columns.Add("Test6", typeof(DateTime));
    dt.Columns.Add("Test7", typeof(int));
    dt.Rows.Add(DateTime.Now);
    dts.Add(dt);
    #endregion
    // sample method usage
    var result = GetJoinedTable(dts);
