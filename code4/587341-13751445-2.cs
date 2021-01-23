    for (int currentRow = 0; currentRow < grv.Rows.Count; currentRow++)
    {
       var rowToCompare = grv.Rows[currentRow]; // Get row to compare against other rows
             
       // Iterate through all rows 
       //
       foreach (var row in grv.Rows)
       {  
           if (rowToCompare.equals(row) continue; // If row is the same row being compared, skip.
    
           bool duplicateRow = true;
           
           // Compare the value of all cells
           //
           for (int cellIndex; cellIndex < row.Cells.Count; cellIndex++)
           {
               if ((null != rowToCompare.Cells[cellIndex].Value) && 
                   (!rowToCompare.Cells[cellIndex].Value.equals(row.Cells[cellIndex].Value)))
              {
                 duplicateRow = false;
                 break;
              }
           }
          
           if (duplicateRow)
           {
               grv.Rows.Remove(row);
           }
       }
    }
