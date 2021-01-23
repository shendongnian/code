    // Work on the first table of the DataSet
    DataTable dt1 = ds.Tables[0];
    // No need to work if we have only 0 or 1 rows
    if(dt1.Rows.Count <= 1) 
         return;
    // Setting the sort order on the desidered column
    dt1.DefaultView.Sort = dt1.Columns[0].ColumnName;
    // Set an initial value ( I choose an empty string but you could set to something not possible here 
    string x = string.Empty;    
    // Loop over the row in sorted order
    foreach(DataRowView dr in dt1.DefaultView)
    {
        // If we have a new value, keep it else delete the row
        if(x != dr[0].ToString())
           x = dr[0].ToString();
        else
           dr.Row.Delete();
 
    }
    // Finale step, remove the deleted rows
    dt1.AcceptChanges();
