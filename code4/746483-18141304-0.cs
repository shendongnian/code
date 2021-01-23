    using (OracleConnection con = new OracleConnection(connectionString))
        {
            con.Open();
            OracleCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE people " +
                              "SET months = :months " +
                              "WHERE number = :number";
            command.Parameters.Add(":months", OracleDbType.Int32).Value = months;
            command.Parameters.Add(":number", OracleDbType.Int32).Value = number;
            
            command.ExecuteNonQuery();
        }
