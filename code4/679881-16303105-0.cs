      using (SqlConnection connection = new SqlConnection(ConnectionString())
      using (SqlCommand cmd = new SqlCommand(updateStatement, connection)) {
        connection.Open();
        cmd.Parameters.Add(new SqlParameter("@Name", userName));
        cmd.Parameters.Add(new SqlParameter("@city", city));
        cmd.Parameters.Add(new SqlParameter("@UserId", userID));
        cmd.ExecuteNonQuery();
      }
