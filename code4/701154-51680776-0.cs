    public static class DataWorker
    {
        public static Func<IEnumerable<T>, Task> GetStoredProcedureWorker<T>(Func<SqlConnection> connectionSource, string storedProcedureName, Func<T, IEnumerable<(string paramName, object paramValue)>> parameterizer)
        {
            if (connectionSource is null) throw new ArgumentNullException(nameof(connectionSource));
            SqlConnection openConnection()
            {
                var conn = connectionSource() ?? throw new ArgumentNullException(nameof(connectionSource), $"Connection from {nameof(connectionSource)} cannot be null");
                var connState = conn.State;
                if (connState != ConnectionState.Open)
                {
                    conn.Open();
                }
                return conn;
            }
            async Task DoStoredProcedureWork(IEnumerable<T> workData)
            {
                using (var connection = openConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = storedProcedureName;
                    command.Prepare();
                    foreach (var thing in workData)
                    {
                        command.Parameters.Clear();
                        foreach (var (paramName, paramValue) in parameterizer(thing))
                        {
                            command.Parameters.AddWithValue(paramName, paramValue ?? DBNull.Value);
                        }
                        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    }
                }
            }
            return DoStoredProcedureWork;
        }
    }
