        /// <summary>
        /// This method internally uses the ExecuteNonQuery method of the SqlCommand object
        /// to run a query that returns no values (updates/inserts/deletes).
        /// </summary>
        /// <param name="sql">The SQL to execute</param>
        /// <param name="parameters">The SqlParameters to use (pass null if there are none)</param>
        /// <remarks>This method is thread safe.</remarks>
        public static void runNonQuery(string sql, IList<SqlParameter> parameters, string dbConnectionString)
        {
            // Old-school, using simple ADO.Net to run a non-query (updates/inserts/deletes) - KDR
            try
            {
                Monitor.Enter(_lock);
                using (SqlConnection conn = new SqlConnection(dbConnectionString))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        if (parameters != null && parameters.Count() != 0)
                        {
                            foreach (SqlParameter param in parameters)
                            {
                                cmd.Parameters.Add(param);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                    if (conn.State != ConnectionState.Closed) { conn.Close(); }
                }
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
