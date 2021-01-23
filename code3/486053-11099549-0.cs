    string connectionString = "......";  // define your connection string here
    string query = "INSERT INTO dbo.YourTableNameHere(XmlColumn) VALUES(@XmlContent)";
    // set up SqlConnection and SqlCommand
    using(SqlConnection conn = new SqlConnection(connectionString))
    using(SqlCommand cmd = new SqlCommand(query, conn))
    {
        // define parameter for query and set its value to your XML response
        cmd.Parameters.Add("@XmlContent", SqlDbType.VarChar, -1);
        cmd.Parameters["@XmlContent"].Value = Response;    // assign your XML response here
        // open connection, execute INSERT, close connection
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();     
    }
