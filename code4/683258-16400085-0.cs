    DataTable dt = rwDB.getCommodities(); 
    var column = dt.Columns.Cast<DataColumn>().FirstOrDefault().ColumnName;
    cboCommodity.DataSource = GetTable();
    cboCommodity.DisplayMember = "Description";
    cboCommodity.ValueMember = column;
