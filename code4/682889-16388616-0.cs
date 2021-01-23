    try
    {
    	conn.Open();
    	MySqlDataReader reader = command.ExecuteReader();
    	while (reader.Read())
    	{
        // do things
    	}
    	conn.Close();
    }
    
    catch (Exception ex)
    {
       Console.Write(ex.Message);
    }
    
           
            
