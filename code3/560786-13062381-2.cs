    List<SqlCeParameters> parameters = new List<SqlCeParameters>();
    parameters.Add(new SqlCeParameter(.....));
    parameters.Add(new SqlCeParameter(.....));
    string query = "...(whatever you need).....";
 
    using(SqlCeConnection conn = new SqlCeConnection(connectionString))
    using(SqlCeCommand cmd = new SqlCeCommand(query, conn))
    { 
        // add all parameters from the list - casting to an array
        cmd.Parameters.AddRange(parameters.ToArray());
        conn.Open();
        cmd.ExecuteNonQuery();  // or whatever you need to do 
        conn.Close();
    }
