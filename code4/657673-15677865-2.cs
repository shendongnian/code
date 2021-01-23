    private bool IsValidUser()
    {
            int result = 0;
            //since executeScalar is intended to retreive only a single value
            //from a query, we select the number of results instead of the email address
            //of each matching result.
            string strQuery = "Select COUNT(Email) From AUser Where Email = @Email And Password = @Password ";
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
    
            SqlCommand Cmd = new SqlCommand(strQuery, con);
            //Cmd.CommandType = CommandType.StoredProcedure;
    
            Cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            Cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            con.Open();
    
            result = (int)Cmd.ExecuteScalar();
            
            //returning a boolean comparator works like this :
            //will return true if the result is greater than zero, but false if it is not.
            return result > 0;
    }
