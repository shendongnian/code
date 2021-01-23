    private OleDbCommand PermanentCommand;
    
    void KeepLinkOpen() {
       if (PermanentCommand == null || 
           PermanentCommand.Connection == null || 
           PermanentCommand.Connection.State == System.Data.ConnectionState.Closed) {
       
         OleDbConnection conn = new OleDbConnection(connectionString);
         conn.Open();
         PermanentCommand = new OleDbCommand("SELECT * FROM DummyTable", conn);
         PermanentCommand.ExecuteReader(System.Data.CommandBehavior.Default);
      }    
    }
    
    void Disconnect() {
      if (PermanentCommand != null) {
          if (PermanentCommand.Connection != null) {
              PermanentCommand.Connection.Close();
          }
          PermanentCommand.Dispose();
          PermanentCommand = null;
      }
    }
