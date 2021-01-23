    var AccessCnn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;", @"C:\YOURDBNAME.accdb");
    
    using (OleDbConnection accessCnn = new OleDbConnection(AccessCnn))
    {
        var placeHolderString = string.Concat(Enumerable.Repeat("?,", 5));
        
        //Create The Command
        var accessCmd = new OleDbCommand(@"INSERT INTO script_Orders  
                                           (Prescription, [Customer Name], Medication, Quantity, [Date Filled])
                                        VALUES (" + placeHolderString + ")", accessCnn);
       
       foreach(var row in dataset.Tables["medTable"])
       {
          accessCmd.Parameters.Clear();
          accessCmd.Parameters.AddWithValue("?", row["Prescription"]);
          accessCmd.Parameters.AddWithValue("?", row["Customer Name"]);
          accessCmd.Parameters.AddWithValue("?", row["Medication"]);
          accessCmd.Parameters.AddWithValue("?", row["Quantity"]);
          accessCmd.Parameters.AddWithValue("?", row["Date Filled"]);
    
          ccessCmd.ExecuteNonQuery();
       }
    								
     								
    }
