    using (var connection = new SqlConnection(ConfigurationManager.AppSettings["connection"])
    using (var command = new SqlCommand(@"select top 1 col_1, col_2 from table1", connection))
    {
        connection.Open();
    
        using (var reader = command.ExecuteReader())
        {
            if (reader.Read()) // Don't assume we have any rows.
            {
                int ord = reader.GetOrdinal("col_1");
                return reader.GetString(ord); // Handles nulls and empty strings.
            }
            return null;
        }
    }
