    public static IDb GetDbInstance()
    {
         string connectionString = GetConnectionStringFromConfigFile();
         string driver = GetDriverFromConnectionString(connectionString);
         if (driver == "SQLite")
            return new Db<SQLiteConnection>(connectionString);
         else if (driver == "MySQL")
            return new Db<MySqlConnection>(connectionString);
         else if (driver == "JET")
            return new Db<OleDbConnection>(connectionString);
         //etc
        return null;
    }
