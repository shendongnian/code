    string value;
    using (SqlCommand command = new SqlCommand("select * from InvPstFile", sqlConnection))
    {
    	SqlDataReader sdr = command.ExecuteReader();
        //Assuming we are just reading 1 row here
        sdr.Read();
    	var bytes = (byte[])sdr["OldRegBinary"];
    
    	// Based on the original unicode format one of the following should 
    	// give you the string value
    	value = System.Text.Encoding.UTF8.GetString(bytes);
    	value = System.Text.Encoding.Unicode.GetString(bytes);
    	value = System.Text.Encoding.Default.GetString(bytes);
    }
