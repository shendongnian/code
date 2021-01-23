    DataTable dt = new DataTable(); 
    //Then fill values 
    DataView dv = dt.AsDataView(); // DataView dv = dt.DefaultView();
    dv.Sort = dv.Table.Columns[index].ColumnName + " DESC";
    dt = dv.Table;
