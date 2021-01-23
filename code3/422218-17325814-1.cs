    //create a DataTable from the filtered DataView
    DataTable filtered = dt.DefaultView.ToTable();
    //loop through the columns of the source table and copy the expression to the new table
    foreach (DataColumn dc in dt.Columns) 
    {
        if (dc.Expression != "")
        {
            filtered.Columns[dc.ColumnName].Expression = dc.Expression;
        }
    }
    dt = filtered;
