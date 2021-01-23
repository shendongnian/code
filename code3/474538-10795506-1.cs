    using (OdbcConnection connection = new OdbcConnection(connectionString))
    using (OdbcCommand command = connection.CreateCommand())
    {
        command.CommandText = commandText //your store procedure name;
        command.CommandType = CommandType.StoredProcedure;
    
        command.Paremeters.Add("@yourParameter", OdbcType.NChar, 50).Value = yourParameter
    
        DataTable dataTable = new DataTable();
    
        connection.Open();    
        using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
        {
            adapter.Fill(dataTable);
        }
    }
