    DataTable originalTable = new DataTable();
    //Load the data into your original table or wherever you get your original table from
    
    DataTable otherTable = originalTable.Copy(); //Copys the table structure only - no data
    
    int rowCount = originalTable.Rows.Count;
    int wayPoint = rowCount / 2; //NB integer division rounds down towards 0
    
    for(int i = 0; i <= wayPoint; i++)
    {
    	otherTable.ImportRow(originalTable.Rows[i]); //Imports (copies) the row from the original table to the new one
    	originalTable.Rows[i].Delete(); //Marks row for deletion
    }
    
    originalTable.AcceptChanges(); //Removes the rows we marked for deletion
