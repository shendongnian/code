    string sqlStoredProcedure = "SelectFromTable";
    using (OdbcConnection dbConnection = new OdbcConnection(dbConnectionString))
    {
        dbConnection.Open();
        using (OdbcCommand command = new OdbcCommand(sqlStoredProcedure, dbConnection))
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new OdbcParameter("@table", tableName));
            using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
            {
                adapter.SelectCommand = command;
                adapter.Fill(tableData);
            }
        }
    }
