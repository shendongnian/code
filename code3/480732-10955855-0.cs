    SqlConnection newConn = new SqlConnection(connectionString);
    newConn.Open();
    myCommand = new SqlCommand(SqlQuery, newConn);
    //Rest of logic
    newConn.Close();
