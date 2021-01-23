      public static OleDbConnection GetDatabaseConnection(string aConnectionString) 
      {
        OleDbConnection _dbConnection  = new OleDbConnection(aConnectionString);
        _dbConnection.Open();
        Log.Logger.log("Aperta connessione al DB");
        return _dbConnection;
      }
