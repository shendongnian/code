    using (SqlConnection conn = new SqlConnection("connectionString")) 
    {
        using (SqlCommand comm = new SqlCommand()) 
        { 
    		cmd.Connection = conn;
    		cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"INSERT INTO klant(klant_id,naam,voornaam) 
                                VALUES(@param1,@param2,@param3)";  
    
            cmd.Parameters.AddWithValue("@param1", klantId));  
            cmd.Parameters.AddWithValue("@param2", klantNaam));  
            cmd.Parameters.AddWithValue("@param3", klantVoornaam));  
    
    		try
    		{
    			conn.Open();
    			cmd.ExecuteNonQuery(); 
    		}
    		catch(SqlException e)
    		{
    			MessgeBox.Show(e.Message.ToString(), "Error Message");
    		}
            
        } 
    }
