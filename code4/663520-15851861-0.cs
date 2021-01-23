    using (SqlCommand command = new SqlCommand("SELECT ID, NAME, AGE WHERE ID = " + row, con))
    {
    
    	SqlDataReader reader = command.ExecuteReader();
    	while (reader.Read())
    	{
           m_stringId = reader.GetInt32(0);   
    	   m_name = reader.GetString(1); 
    	   m_age = reader.GetString(2); 
    	}
    }
 
