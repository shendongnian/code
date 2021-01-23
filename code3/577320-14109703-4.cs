    using (OdbcConnection odbcConnection = new OdbcConnection(db2ConnectionString))
    {
        odbcConnection.Open();
        // string commandText = "";
        using (OdbcCommand command = new OdbcCommand(commandText, odbcConnection))
        {
            command.CommandType = System.Data.CommandType.Text;
            using (OdbcDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                    }
                }
            }
        }
    }
