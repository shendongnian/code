    using (SqlCommand cmd = new SqlCommand(sql))
      
    {
        // Create the parameter objects as specific as possible.
        cmd.Parameters.Add("@UserName", System.Data.SqlDbType.NVarChar, 50);
        cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 25);
      
        // Add the parameter values.  Validation should have already happened.
        cmd.Parameters["@UserName"].Value = UserName;
        cmd.Parameters["@Password"].Value = Password;
        cmd.Connection = connnection;
      
        try
        {
            cmd.Connection.Open();
            var userId = cmd.ExecuteScalar();
        }
        catch (SqlException sx)
        {
            // Handle exceptions before moving on.
        }
    }
