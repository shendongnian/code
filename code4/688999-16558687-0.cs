    DataTable dtDataSource = new DataTable();
    
    dtDataSource.Columns.Add("Value");
    dtDataSource.Columns.Add("Display");
    dtDataSource.Rows.Add(new object[] { 1, 1});
    dtDataSource.Rows.Add(new object[] { 2, 2 });
    dtDataSource.Rows.Add(new object[] { 3, 3 });
    dtDataSource.Rows.Add(new object[] { 4, 4 });
    dtDataSource.Rows.Add(new object[] { 5, 5 });
    
    var results = dtDataSource.AsEnumerable().Max(row => Convert.ToInt32(row["Value"]));
