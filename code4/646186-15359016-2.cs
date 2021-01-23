    SqlConnection dbConnection;
    dbConnection = new SqlConnection(connectionString);
    SqlCommand myCommand = new SqlCommand("SELECT * FROM Employee WHERE F_name=@F_name", dbConnection);
    SqlParameter sqlParam = new SqlParameter("@F_name", F_name);
    myCommand.Parameters.Add(sqlParam);
    myCommand.Connection.Open();
    SqlDataReader myReader = myCommand.ExecuteReader();
    string name = "";
    if (myReader.Read())
    {
        name = myReader.GetString("F_name");
        // now you get 'name' from DB here, do your job
    }
    myReader.Close();
    myCommand.Connection.Close();
