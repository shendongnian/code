    string connectionString = "...";
    string query = "...";
    using (var connection = new OracleConnection(connectionString)) {
        var command = new OracleCommand(query);
        command.Parameters.Add(":DESCSITE", OracleType.NVarChar);
        connection.Open();
        using (OracleDataReader reader = command.ExecuteReader()) {
            int descSiteOrdinal = reader.GetOrdinal("DESCSITE");
            while (reader.Read()) {
                Console.WriteLine(reader.GetString(descSiteOrdinal));
            }
        }
    }
