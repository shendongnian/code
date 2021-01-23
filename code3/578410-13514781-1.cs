        /// <summary>
        /// Execute commands with an open SQL connection.
        /// Note: To execute a stored procedure send to useTransaction parameter false value
        /// </summary>
        /// <param name="connection">An opened SqlConnection</param>
        /// <param name="commands">A string array of the requested commands to execute</param>
        /// <param name="useTransaction">true if to force transaction, false to execute the commands without transaction</param>
        /// <returns>true for success, otherwise false</returns>
        public static bool ExecuteSqlCommands(SqlConnection connection, string[] commands, bool useTransaction)
        {
            bool bStatus = false;
            string[] lines = commands; // regex.Split(sql);
            SqlTransaction transaction = null;
            if (useTransaction)
                transaction = connection.BeginTransaction();
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.Connection = connection;
                if (useTransaction)
                    cmd.Transaction = transaction;
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        cmd.CommandText = line;
                        cmd.CommandType = CommandType.Text;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            string msg = e.Message;
                            if (useTransaction)
                                transaction.Rollback();
                            throw;
                        }
                    }
                }
                bStatus = true;
            }
            if (bStatus && useTransaction)
                transaction.Commit();
            return bStatus;
        }
