    public static class Db
    {
        static IDb db = GetDbInstance();
        static IDb GetDbInstance()
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
        public static void Parameterize(this IDbCommand command, string name, 
                                        object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
        public static IEnumerable<T> Get<T>(string query, 
                                            Action<IDbCommand> parameterizer, 
                                            Func<IDataRecord, T> selector)
        {
            return db.Get(query, parameterizer, selector);
        }
        public static int Add(string query, Action<IDbCommand> parameterizer)
        {
            return db.Add(query, parameterizer);
        }
        public static int Save(string query, Action<IDbCommand> parameterizer)
        {
            return db.Save(query, parameterizer);
        }
        public static int SaveSafely(string query, Action<IDbCommand> parameterizer)
        {
            return db.SaveSafely(query, parameterizer);
        }
    }
