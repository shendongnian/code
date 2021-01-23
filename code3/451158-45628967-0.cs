    for (int i = 0; i < dataGridName.Items.Count; i++)
    {
          string cellValue= ((DataRowView)dataGridName.Items[i]).Row["columnName"].ToString();                
          if (cellValue.Equals("Search_string")) // check the search_string is present in the row of ColumnName
          {
             object item = dataGridName.Items[i];
             dataGridName.SelectedItem = item; // selecting the row of dataGridName
             dataGridName.ScrollIntoView(item);                    
             break;
          }
    }
