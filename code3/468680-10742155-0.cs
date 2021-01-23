       // Build the connection string
          string connectionString = @"Provider=VFPOLEDB.1;Data Source= myServer;Collating Sequence=general";
    
          // Create the connection
          OleDbConnection connection = new OleDbConnection(connectionString);
    
          // Open the connection
          connection.Open();
