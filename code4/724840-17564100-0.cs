    private void GetRowsByFilter()
       {
           DataTable table = DataSet1.Tables["YourTable"];
    
           // Presuming the DataTable has a column named Date.
           string expression = "Column_name = ''";
    
           // Sort descending by column named CompanyName.
           string sortOrder = "ColumnName DESC";
           DataRow[] foundRows;
    
           // Use the Select method to find all rows matching the filter.
           foundRows = table.Select(expression, sortOrder);
    
           // Print column 0 of each returned row.
           for(int i = 0; i < foundRows.Length; i ++)
           {
               Console.WriteLine(foundRows[i][0]);
           }
       }
