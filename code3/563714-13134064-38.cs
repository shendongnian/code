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
        public static void Parameterize<T>(this IDbCommand command, string name, 
                                           T value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
        public static int Add(string query, Action<IDbCommand> parameterizer)
        {
            return db.Add(query, parameterizer);
        }
        public static int Save(string query, Action<IDbCommand> parameterizer)
        {
            return db.Save(query, parameterizer);
        }
        public int SaveSafely(string query, Action<IDbCommand> parameterizer);
        {
            return db.SaveSafely(query, parameterizer);
        }
        public IEnumerable<T> Get<T>(string query, Action<IDbCommand> parameterizer, 
                                     Func<IDataRecord, T> selector)
        {
            return db.Read(query, parameterizer, selector);
        }
    }
