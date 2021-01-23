    StringBuilder filter = new StringBuilder();
    
    foreach(var column in DataRow.Table.Columns)
    {
       if(filter.ToString() == "")
       {
           filter.Append(column.ColumnName + " like '" + searchText.Text + "'");
       }
       else 
       {
          filter.Append(" OR ");
          filter.Append(column.ColumnName + " like '" + searchText.Text + "'");
       }
    }
    
    RowFilter = filter.ToString();
