    using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from users where user_name like @username AND password like @password", sqlConnection))
    {
        sqlConnection.Open();
        sqlCommand.Parameters.AddWithValue("@username", userName);
        sqlCommand.Parameters.AddWithValue("@password", passWord);
        int userCount = sqlCommand.ExecuteScalar();
        ...
    }
