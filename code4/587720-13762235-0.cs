    DataTable dt = new DataTable(); 
    //Then fill values 
    DataView dv = dt.AsDataView(); 
    dv.Sort = dv.Table.Columns[index].ColumnName + " DESC";
    dt = dv.Table;
