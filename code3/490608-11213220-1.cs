    string connectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated  Security=True;User Instance=True";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    
        using (SqlCommand insertCommand = connection.CreateCommand())
    
            {
                insertCommand.CommandText = "INSERT INTO address(name,age,city) VALUES (@na,@ag,@ci)";
                insertCommand.Parameters.Add("@na", na);
                insertCommand.Parameters.Add("@ag", ag);
                insertCommand.Parameters.Add("@ci", ci);
              
    
                insertCommand.Connection.Open();
                insertCommand.ExecuteNonQuery();
               
    
            }
    }
