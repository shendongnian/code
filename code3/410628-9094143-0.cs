      SqlDataAdapter adapter = new SqlDataAdapter();
    
        // Create the SelectCommand.
        SqlCommand command = new SqlCommand(Select youthclubname from youthclublist WHERE ([YouthClubID] = @YouthClubID)", sqlConnection);
    
        // Add the parameters for the SelectCommand.
        command.Parameters.AddWithValue("@YouthClubID", yourYouthClubID);
        yourClubName = sqlCommand.ExecuteScalar();
       
