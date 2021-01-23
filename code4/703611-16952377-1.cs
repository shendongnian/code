    StringBuilder filter = new StringBuilder();
    
    foreach(var column in dataGridView.Columns)
    {
       if(filter.ToString() == "")
       {
           filter.Append(column.Name + " like '" + searchText.Text + "'");
       }
       else 
       {
          filter.Append(" OR ");
          filter.Append(column.Name + " like '" + searchText.Text + "'");
       }
    }
    
    RowFilter = filter.ToString();
