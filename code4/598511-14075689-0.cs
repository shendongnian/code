        public static T ExecuteReader<T>(IDbConnection connection, string commandText, Func<IDataReader, T> readData) where T : class
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            try
            {
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                T returnValue = readData(reader); //Call the code provided by the caller and get the return object.
                reader.Close();
                reader.Dispose();
                return returnValue; //Return their return object.
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                }
                if (connection != null)
                {
                    try
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                    }
                    finally
                    {
                        connection.Dispose();
                    }
                }
            }
        }
