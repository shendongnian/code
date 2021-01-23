    updateConnection = new System.Data.OleDb.OleDbConnection();
    updateConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\spreston\documents\visual studio 2012\Projects\roomChecksProgram\roomChecksProgram\roomsBase.accdb";
    
    updateConnection.Open();
    
    MessageBox.Show("Connected");
    
    string updateCommand = "UPDATE RoomsTable SET Date Checked= '"+9/27/2012+"' ";
    
    updateAdapter = new OleDbDataAdapter(updateCommand, updateConnection);
    
    updateConnection.Close();
    updateConnection.Dispose();
