        public static Db GetDbInstance()
        {
             string connectionString = GetConnectionStringFromConfigFile();
             string driver = GetDriverFromConnectionString(connectionString);
             if (driver == "Sqlite")
                return new Db<SQLiteConnection, SQLiteCommand>(connectionString);
             else if (driver == "MySQL")
                return new Db<MySQLConnection, MySQLCommand>(connectionString);
             else if (driver == "JET")
                return new Db<OleDbConnection, OleDbCommand>(connectionString);
             //etc
            return null;
        }
