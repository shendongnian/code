    string sql = "SELECT TOP 10 * FROM {0}";
    using (OdbcConnection dbConnection = new OdbcConnection(dbConnectionString))
    {
        dbConnection.Open();
        DataTable tables = dbConnection.GetSchema(OdbcMetaDataCollectionNames.Tables);
        var matches = tables.Select(String.Format("TABLE_NAME = '{0}'", tableName));
        //check if table exists
        if (matches.Count() > 0)
        {
            using (OdbcCommand command = new OdbcCommand(String.Format(sql, tableName), dbConnection))
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(tableData);
                }
            }
        }
        else
        {
            //handle invalid value
        }
    }
