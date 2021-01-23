        using (var sqlConnection = new SqlConnection(@"Data Source=myServerAddress;User Id=myUsername;Password=myPassword;"))
        {
            sqlConnection.Open();
            string query = "CREATE DATABASE...";
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.ExecuteNonQuery();
            }
        }
