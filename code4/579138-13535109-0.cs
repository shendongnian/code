    string connectionString= "Data Source=.\\SQLExpress;Trusted_Connection=True;User Instance=True;AttachDbFilename=|DataDirectory|\\fbi.mdf;";
    string query = "SELECT Car FROM tbl1 JOIN tbl2 ON (tbl1.userID = tbl2.userID) WHERE tbl2.username='Bob'";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ddl1.Items.Add(reader.GetValue(0).ToString());
                }
            }
        }
    }
