        /// <summary>
        /// Executes the provided CommandText against the Oracle database.
        /// </summary>
        /// <param name="commandText">The command to execute</param>
        /// <exception cref="ArgumentNullException">Thrown if an empty or null commandText is provided</exception>
        private void ExecuteOracleTextCommand(string commandText)
        {
            if(string.IsNullOrWhiteSpace(commandText)
            {
                throw new ArgumentNullException("commandText", "Please provide a valid command");
            }
            //other commandText validation here...
            OracleConnection myOracleConnection = new OracleConnection(connectionString);
            myOracleConnection.Open();
            OracleCommand command = myOracleConnection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = System.Data.CommandType.Text;
            command.ExecuteNonQuery();
            myOracleConnection.Close();
        }
