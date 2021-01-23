    public static IDb GetDbInstance()
    {
         string connectionString = GetConnectionStringFromConfigFile();
         string driver = GetDriverFromConnectionString(connectionString);
         if (driver == "SQLite")
            return new Db<SQLiteConnection, SQLiteCommand>(connectionString);
         else if (driver == "MySQL")
            return new Db<MySqlConnection, MySqlCommand>(connectionString);
         else if (driver == "JET")
            return new Db<OleDbConnection, OleDbCommand>(connectionString);
         //etc
        return null;
    }
