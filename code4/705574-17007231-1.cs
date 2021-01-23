    public override bool ChangePassword(string username, string oldPwd, string newPwd)
    {
    	// validate the user first, you are not doing any validation 
    	// logged in user can change any other users password in your approach 
    	if (!ValidateUser(username, oldPwd))
    	return false;
    
    	//new password validation and giving proper message if failed 
        // skip this code from given link
    
        // use parameterized query as below 
    	OdbcConnection conn = new OdbcConnection(connectionString);
    	OdbcCommand cmd = new OdbcCommand("UPDATE Users "  +
    		  " SET Password = ?, LastPasswordChangedDate = ? " +
    		  " WHERE Username = ? AND ApplicationName = ?", conn);
    
    	cmd.Parameters.Add("@Password", OdbcType.VarChar, 255).Value = EncodePassword(newPwd);
    	cmd.Parameters.Add("@LastPasswordChangedDate", OdbcType.DateTime).Value = DateTime.Now;
    	cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
    	cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;
    
    
    	int rowsAffected = 0;
    
    	try
    	{
    		conn.Open();
                // this is how you can check whether row updated or not 
    		rowsAffected = cmd.ExecuteNonQuery();
    	}
    	catch (OdbcException e)
    	{
    		// you need to have proper error handling as well 
    		if (WriteExceptionsToEventLog)
    		{
    		  WriteToEventLog(e, "ChangePassword");
    
    		  throw new ProviderException(exceptionMessage);
    		}
    		else
    		{
    		  throw e;
    		}
    	}
    	finally
    	{
    		conn.Close();
    	}
    
    	if (rowsAffected > 0)
    	{
    		return true;
    	}
    
    	return false;
    }
