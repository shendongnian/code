    string strSession = objGetSession.GetEmailFromSession();			
    string connString = "connection string here";
    string strInsertFnLn = @"
    							UPDATE	a
    							SET		a.FirstName = @FirstName,
    									a.LastName = @LastName
    							FROM	AUserAddress a
    									INNER JOIN AUser b
    										ON a.AUser_ID = b.ID
    							WHERE	b.Email = @Email
    						";
    using (SqlConnection con = new SqlConnection(connString))
    {
    	using (SqlCommand Cmd = new SqlCommand(strInsertFnLn, con))
    	{
    		Cmd.Parameters.AddWithValue("@FirstName", txtEditFirstName.Text);
    		Cmd.Parameters.AddWithValue("@LastName", txtEditLastName.Text);
    		Cmd.Parameters.AddWithValue("@Email", strSession);
    		try
    		{
    			con.Open();
    			Cmd.ExecuteNonQuery();
    		}
    		catch (SqlException ex)
    		{
    			// do something with the exception
    			// don't hide it
    		}
    	}
    }
