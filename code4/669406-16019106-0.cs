    using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();
        using (SqlCommand queryCommand = new SqlCommand(QueryString, connection))
        {
            try
            {
                queryCommand.ExecuteScalar();
            } catch (Exception ex)
            { 
                // log this exception or do something else useful 
            }
            // now do something else with the command/connection
        }
    }
