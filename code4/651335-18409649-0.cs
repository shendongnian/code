    public static SQLite Instance
    {
      get
      {
        if (instance == null) 
          {
            instance = new SQLite();
            mySQLiteConn = new SQLiteConnection(ConnectionString);
            mySQLiteConn.Open();
          }
          return instance;
      }
    }
    public void Execute(string SQL)
    {
      using (SQLiteCommand myCommand = new SQLiteCommand(SQL, mySQLiteConn))
      {
        myCommand.ExecuteNonQuery().ToString();
      }
    }
