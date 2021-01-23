    string connectionString = "(your connection string here)";
    string commandText = "usp_YourStoredProc";
    
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
    SqlCommand cmd = new SqlCommand(commandText, conn);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandTimeout = 600;
    
    conn.Open();
    SqlDataReader dr = cmd.ExecuteReader();
    while(dr.Read())
    {
    // your code to fetch here.
    }
    conn.Close();
    
    }
