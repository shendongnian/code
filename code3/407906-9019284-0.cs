    int i = 0;
    try
    {
        // Some code here - which could throw an exception
       
        try{
            foreach (DataRow row in DataTables[0].Rows)
            {
                // My stuff
                i++;
            }
            // Some code here - which could throw an exception
        }
        catch{
          i--;
          throw;
        }
        
    }
    catch
    {
        // Use the counter
        DataRow row = DataTables[0].Rows[i];
    }
