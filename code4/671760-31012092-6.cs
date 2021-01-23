                // Early on...
                OracleConnection _connection = DbConnectionsManager.GetDatabaseConnection(aDbConnectionString);
                // ... Later on, in various other calls ...
                using (new OpenedContext(_connection))
                {
                    OracleCommand command = _connection.CreateCommand();
                    string sql = "SELECT * FROM MYTABLE";
                    command.CommandText = sql;
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string myField = (string)reader["EXAMPLE"];
                        Console.WriteLine(myField);
                    }
                }
