    public abstract class BaseRepo
    {
        private string _connectionString;
        protected BaseRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        private SqlConnection GetSqlConnection(int commandTimeout, CommandType commandType, ref SqlCommand sqlCmd)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            sqlCmd.Connection = connection;
            sqlCmd.CommandTimeout = commandTimeout;
            sqlCmd.CommandType = commandType;
            return connection;
        }
        protected int ExecuteSql(SqlCommand sqlCmd, int commandTimeout = 30, CommandType commandType = CommandType.Text)
        {
            using (var connection = GetSqlConnection(commandTimeout, commandType, ref sqlCmd))
            {
                return sqlCmd.ExecuteNonQuery();
            }
        }
        protected IEnumerable<T> ExecuteSqlReader<T>(Func<IDataRecord, T> CreateObject, SqlCommand sqlCmd, int commandTimeout = 30, CommandType commandType = CommandType.Text)
        {
            using (var connection = GetSqlConnection(commandTimeout, commandType, ref sqlCmd))
            {
                using (var reader = sqlCmd.ExecuteReader())
                    return ExecuteReader(CreateObject, reader);
            }
        }
        protected Tuple<IEnumerable<T1>, IEnumerable<T2>> ExecuteSqlReader<T1,T2>(Func<IDataRecord, T1> CreateObject1, Func<IDataRecord, T2> CreateObject2,  SqlCommand sqlCmd, int commandTimeout = 30, CommandType commandType = CommandType.Text)
        {
            using (var connection = GetSqlConnection(commandTimeout, commandType, ref sqlCmd))
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    var result1 = ExecuteReader(CreateObject1, reader).ToList();
                    var result2 = ExecuteReader(CreateObject2, reader).ToList();
                    return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>>(result1, result2);
                }
            }
        }
        protected Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> ExecuteSqlReader<T1, T2, T3>(Func<IDataRecord, T1> CreateObject1, Func<IDataRecord, T2> CreateObject2, Func<IDataRecord, T3> CreateObject3, SqlCommand sqlCmd, int commandTimeout = 30, CommandType commandType = CommandType.Text)
        {
            using (var connection = GetSqlConnection(commandTimeout, commandType, ref sqlCmd))
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    var result1 = ExecuteReader(CreateObject1, reader).ToList();
                    var result2 = ExecuteReader(CreateObject2, reader).ToList();
                    var result3 = ExecuteReader(CreateObject3, reader).ToList();
                    return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(result1, result2, result3);
                }
            }
        }
        protected Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>> ExecuteSqlReader<T1, T2, T3, T4>(Func<IDataRecord, T1> CreateObject1, Func<IDataRecord, T2> CreateObject2, Func<IDataRecord, T3> CreateObject3, Func<IDataRecord, T4> CreateObject4, SqlCommand sqlCmd, int commandTimeout = 30, CommandType commandType = CommandType.Text)
        {
            using (var connection = GetSqlConnection(commandTimeout, commandType, ref sqlCmd))
            {
                using (var reader = sqlCmd.ExecuteReader())
                {
                    var result1 = ExecuteReader(CreateObject1, reader).ToList();
                    var result2 = ExecuteReader(CreateObject2, reader).ToList();
                    var result3 = ExecuteReader(CreateObject3, reader).ToList();
                    var result4 = ExecuteReader(CreateObject4, reader).ToList();
                    return Tuple.Create<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>(result1, result2, result3, result4);
                }
            }
        }
        private IEnumerable<T> ExecuteReader<T>(Func<IDataRecord, T> CreateObject, SqlDataReader reader)
        {
            while (reader.Read())
            {
                yield return CreateObject(reader);
            }
            reader.NextResult();
        }
    }
