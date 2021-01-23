    SqlConnection sqlConnection = new SqlConnection("...");
    SqlCommand command = new SqlCommand("Select youthclubname from youthclublist WHERE ([YouthClubID] = @YouthClubID)", sqlConnection);
    command.Parameters.Add("@YouthClubID", SqlDbType.Int);
    command.Parameters["@YouthClubID"].Value = clubID;
    
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
